using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;

namespace Pattern_ProxyServer
{
    public interface State
    {
        String gotApplication();
        String checkApplication();
        String rentApartment();
        String dispenseKeys();
    }

    public interface AutomatInterface
    {
        string gotApplication();
        string checkApplication();
        string rentApartment();
        void setState(State s);
        State getWaitingState();
        State getGotApplicationState();
        State getApartmentRentedState();
        State getFullyRentedState();
        int getCount();
        void setCount(int n);
    }

    public class Automat : AutomatInterface
    {
        State waitingState;
        State gotApplicationState;
        State apartmentRentedState;
        State fullyRentedState;
        State state;
        int count;

        public Automat(int n)
        {
            count = n;
            waitingState = new WaitingState(this);
            gotApplicationState = new GotApplicationState(this);
            apartmentRentedState = new ApartmentRentedState(this);
            fullyRentedState = new FullyRentedState(this);
            state = waitingState;

            try
            {
                // Precisa estar escutando na porta correta , 
                //tem que ser a mesma porta na qual o cliente vai usar
                IPAddress[] ips = Dns.GetHostAddresses("localhost");
                var adress = ips.Length == 0 ? System.Net.IPAddress.Any : ips[1];
                const int numeroPorta = 8000;
                TcpListener tcpListener = new TcpListener(adress, numeroPorta);
                tcpListener.Start();

                Console.WriteLine("Aguardando uma conexão...");

                // aceita a conexao do cliente e retorna uma inicializacao TcpClient 
                using (TcpClient tcpClient = tcpListener.AcceptTcpClient())
                {
                    Console.WriteLine("Conexão aceita.");

                    // obtem o stream
                    NetworkStream networkStream_read = tcpClient.GetStream();
                    NetworkStream networkStream_write = tcpClient.GetStream();

                    if (networkStream_write.CanWrite & networkStream_read.CanRead)
                    {
                        string responseString = "Conectado ao servidor.";
                        Byte[] sendBytes = Encoding.ASCII.GetBytes(responseString);
                        networkStream_write.Write(sendBytes, 0, sendBytes.Length);

                        bool completed = false;
                        while (!completed)
                        {
                            // Le o NetworkStream em um buffer
                            byte[] bytes = new byte[tcpClient.ReceiveBufferSize + 1];

                            networkStream_read.Read(bytes, 0, System.Convert.ToInt32(tcpClient.ReceiveBufferSize));

                            // exibe os dados recebidos do host no console
                            string clientdata = Encoding.ASCII.GetString(bytes);
                            clientdata = clientdata.Replace("\0", "");
                            Console.WriteLine(("Client enviou: " + clientdata));

                            // qualquer comunicacao com o cliente remoto usando o TcpClient pode comecar aqui
                            //var automat = new Automat(9);
                            if (clientdata.Equals("gotApplication"))
                            {
                                responseString = gotApplication();
                                responseString = responseString + "\n" + checkApplication();
                            }
                            else if (clientdata.Equals("checkApplication"))
                            {
                                responseString = checkApplication();
                            }
                            else if (clientdata.Equals("rentApartment"))
                            {
                                responseString = rentApartment();
                            }

                            sendBytes = Encoding.ASCII.GetBytes(responseString);
                            networkStream_write.Write(sendBytes, 0, sendBytes.Length);

                            Console.WriteLine(("Mensagem enviada /> : " + responseString));

                            if (clientdata == "tchau" || clientdata == "quit"
                                || clientdata == "fim" || clientdata == "exit") completed = true;
                        }
                    }
                    else if (!networkStream_read.CanRead)
                    {
                        Console.WriteLine("Não é possível enviar dados para este stream");

                        tcpClient.Close();
                    }
                    else if (!networkStream_write.CanWrite)
                    {
                        Console.WriteLine("Não é possivel ler dados deste stream");

                        tcpClient.Close();
                    }
                }

                tcpListener.Stop();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string gotApplication()
        {
            return state.gotApplication();
        }
        public string checkApplication()
        {
            return state.checkApplication();
        }
        public string rentApartment()
        {
            return state.rentApartment();
        }

        public void setState(State s) { state = s; }
        public State getWaitingState() { return waitingState; }
        public State getGotApplicationState() { return gotApplicationState; }
        public State getApartmentRentedState() { return apartmentRentedState; }
        public State getFullyRentedState() { return fullyRentedState; }
        public int getCount() { return count; }
        public void setCount(int n) { count = n; }
    }


    public class WaitingState : State
    {
        AutomatInterface automat;
        public WaitingState(AutomatInterface a)
        {
            automat = a;
        }
        public String gotApplication()
        {
            automat.setState(automat.getGotApplicationState());
            return "Thanks for the application.";
        }
        public String checkApplication() { return "You have to submit an application."; }
        public String rentApartment() { return "You have to submit an application."; }
        public String dispenseKeys() { return "You have to submit an application."; }
    }

    public class GotApplicationState : State
    {
        AutomatInterface automat;
        Random random;
        public GotApplicationState(AutomatInterface a)
        {
            automat = a;
            random = new Random(DateTime.Now.Millisecond);
        }
        public String gotApplication()
        {
            return "We already got your application.";
        }
        public String checkApplication()
        {
            int yesno = random.Next() % 10;
            if (yesno > 4 && automat.getCount() > 0)
            {
                automat.setState(automat.getApartmentRentedState());

                return "Congratulations, you were approved.\n" + automat.rentApartment();
            }
            else
            {
                automat.setState(automat.getWaitingState());
                return "Sorry, you were not approved.";
            }
        }
        public String rentApartment()
        {
            return "You must have your application checked.";
        }
        public String dispenseKeys()
        {
            return "You must have your application checked.";
        }
    }

    public class ApartmentRentedState : State
    {
        AutomatInterface automat;
        public ApartmentRentedState(AutomatInterface a)
        {
            automat = a;
        }
        public String gotApplication()
        {
            return "Hang on, we’re renting you an apartment.";
        }
        public String checkApplication()
        {
            return "Hang on, we’re renting you an apartment.";
        }
        public String rentApartment()
        {
            automat.setCount(automat.getCount() - 1);
            return "Renting you an apartment....\n" + dispenseKeys();
        }
        public String dispenseKeys()
        {
            if (automat.getCount() <= 0)
            {
                automat.setState(automat.getFullyRentedState());
            }
            else
            {
                automat.setState(automat.getWaitingState());
            }
            return "Here are your keys!";
        }
    }

    public class FullyRentedState : State
    {
        AutomatInterface automat;
        public FullyRentedState(AutomatInterface a)
        {
            automat = a;
        }
        public String gotApplication() { return "Sorry, we’re fully rented."; }
        public String checkApplication() { return "Sorry, we’re fully rented."; }
        public String rentApartment() { return "Sorry, we’re fully rented."; }
        public String dispenseKeys() { return "Sorry, we’re fully rented."; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var automatProxy = new Automat(9);
        }
    }
}
