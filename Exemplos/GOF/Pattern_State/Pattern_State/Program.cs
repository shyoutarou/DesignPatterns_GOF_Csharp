using System;

namespace Pattern_State
{
    public class RentalMethods
    {
        const int FULLY_RENTED = 0;
        const int WAITING = 1;
        const int GOT_APPLICATION = 2;
        const int APARTMENT_RENTED = 3;
        Random random;
        int numberApartments;
        int state = WAITING;
        public RentalMethods(int n)
        {
            numberApartments = n;
            random = new Random(DateTime.Now.Millisecond);
        }
        public void getApplication()
        {
            int yesno = random.Next() % 10;

            switch (state)
            {
                case FULLY_RENTED:
                    Console.WriteLine("Sorry, we’re fully rented.");
                    break;
                case WAITING:
                    state = GOT_APPLICATION;
                    Console.WriteLine("Thanks for the application.");
                    break;
                case GOT_APPLICATION:
                    Console.WriteLine("We already got your application.");
                    break;
                case APARTMENT_RENTED:
                    Console.WriteLine("Hang on, we’re renting you an apartment.");
                    break;
            }
        }

        public void checkApplication()
        {
            int yesno = random.Next() % 10;

            switch (state)
            {
                case FULLY_RENTED:
                    Console.WriteLine("Sorry, we’re fully rented.");
                    break;
                case WAITING:
                    state = GOT_APPLICATION;
                    Console.WriteLine("You have to submit an application.");
                    break;
                case GOT_APPLICATION:
                    if (yesno > 4 && numberApartments > 0)
                    {
                        Console.WriteLine("Congratulations, you were approved.");
                        state = APARTMENT_RENTED;
                        rentApartment();
                    }
                    else
                    {
                        Console.WriteLine("Sorry, you were not approved.");
                        state = WAITING;
                    }
                    break;
                case APARTMENT_RENTED:
                    Console.WriteLine("Hang on, we’re renting you an apartment.");
                    break;
            }
        }

        public void rentApartment()
        {
            switch (state)
            {
                case FULLY_RENTED:
                    Console.WriteLine("Sorry, we’re fully rented.");
                    break;
                case WAITING:
                    Console.WriteLine("You have to submit an application.");
                    break;
                case GOT_APPLICATION:
                    Console.WriteLine("You must have your application checked.");
                    break;
                case APARTMENT_RENTED:
                    Console.WriteLine("Renting you an apartment....");
                    numberApartments--;
                    dispenseKeys();
                    break;
            }
        }

        public void dispenseKeys()
        {
            switch (state)
            {
                case FULLY_RENTED:
                    Console.WriteLine("Sorry, we’re fully rented.");
                    break;
                case WAITING:
                    Console.WriteLine("You have to submit an application.");
                    break;
                case GOT_APPLICATION:
                    Console.WriteLine("You must have your application checked.");
                    break;
                case APARTMENT_RENTED:
                    Console.WriteLine("Here are your keys!");
                    state = WAITING;
                    break;
            }
        }
    }

    public interface State
    {
        String gotApplication();
        String checkApplication();
        String rentApartment();
        String dispenseKeys();
    }

    public interface AutomatInterface
    {
        void gotApplication();
        void checkApplication();
        void rentApartment();
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
        }
        public void gotApplication()
        {
            Console.WriteLine(state.gotApplication());
        }
        public void checkApplication()
        {
            Console.WriteLine(state.checkApplication());
        }
        public void rentApartment()
        {
            Console.WriteLine(state.rentApartment());
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
                automat.rentApartment();
                return "Congratulations, you were approved.";
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
            Console.WriteLine(dispenseKeys());
            return "Renting you an apartment....";
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
            //TestRentalMethods();
            TestAutomatClasses();
            Console.ReadKey();
        }

        public static void TestRentalMethods()
        {
            var rentalMethods = new RentalMethods(9);
            rentalMethods.getApplication();
            rentalMethods.checkApplication();
        }

        public static void TestAutomatClasses()
        {
            var automat = new Automat(9);
            automat.gotApplication();
            automat.checkApplication();
        }
    }
}
