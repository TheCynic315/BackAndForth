using System;
using System.Text;
using Crestron.SimplSharp;                          				// For Basic SIMPL# Classes



namespace backandforth
{

    public delegate void SimplPlusCallBack(SimplSharpString s); //used to get the data back to S+
    
    //Stores the data that we pass back and forth. Inhearet from EventArgs
    public class TestEventArgs : EventArgs
    {
        public string Title { get; set; }
        public string ReleaseDate { get; set; }

        public TestEventArgs(){} //default constructor because S+ sucks
    }

   
    /* Testing of Callback Functions to S+.
     * When the event is fired this function updates a second S+ module of the Title
     * of the Star Wars film. (well the abreavition of it)
     * This class uses the same event from EventTesting and the same signature for
     * the callback delegeate.
     */

    public class CallBackTesting
    {

        public SimplPlusCallBack HeySimplPlus { get; set; }

        public CallBackTesting() { } //default constructor because s+ sucks

        //call to subscribe to the event. The event is from a differnt class so we need to remeber that.
        public void Setup()
        {
            EventTesting.myEvent += new EventTesting.TestEvent(EventTesting_myEvent);
        }

        //The event. When it is fired it sends back the string for the Movie's title to s+.
        public void EventTesting_myEvent(object o, TestEventArgs e)
        {
            //CrestronConsole.PrintLine("Made it to Callback Event Test. Contents of e: {0}", e.Title);
            HeySimplPlus(e.Title);
        }


    }

    /*This class contains tests Events and sending data between classes and S+.
    * To do this we have a function that is called from S+, once we check 
    * that data we then notifiy the event.
    * In this case Entering in the Episode Number from a Star Wars film will
    * notify the event and a String is spat out containing 
    * that episode's release date.
    */

    public class EventTesting
    {

        public EventTesting() { } //default constructor because S+ sucks

        public SimplPlusCallBack HeySimplPlus { get; set; }

        public static event TestEvent myEvent = delegate { }; //set the event as a delegate to remove need to check for null.

        public delegate void TestEvent(object o, TestEventArgs e); //This is how an event must be delared for S+

        


        /*Setup function called from S+ this will set up our subscriptions.
         * Subscriptions are who is listening for an event to fire off.
        */
        public void Setup()
        {
            myEvent += new EventTesting.TestEvent(thisEvent_myEvent);
        }

        /*One of our events. All the data we want to play with is in e.
         * in this extended example the event will also send back
         * data to s+. In this case it is the release date of the movie
         */
        public void thisEvent_myEvent(object o, TestEventArgs e)
        {
            //CrestronConsole.PrintLine("Made it to EventTesting Event");
            HeySimplPlus(e.ReleaseDate);// send the data back to S+
            //CrestronConsole.PrintLine("Should have clled the callback function");

        }

        //Called from S+ this just does some work then calls the function to fire the event.
        public void GetData(ushort _id)
        {
            var args = new TestEventArgs();

            switch (_id)
            {
                case 1:
                    args.Title = "TPM";
                    args.ReleaseDate = "May 19 1999";
                    break;
                case 2:
                    args.Title = "AotC";
                    args.ReleaseDate = "May 16 202";
                    break;
                case 3:
                    args.Title = "RtotS";
                    args.ReleaseDate = "May 19 2005";
                    break;
                case 4:
                    args.Title = "ANH";
                    args.ReleaseDate = "May 25 1977";
                    break;
                case 5:
                    args.Title = "ESB";
                    args.ReleaseDate = "May 21 1980";
                    break;
                case 6:
                    args.Title = "RotJ";
                    args.ReleaseDate = "May 25 1983";
                    break;
                case 7:
                    args.Title = "TFA";
                    args.ReleaseDate = "December 18 2015";
                    break;
                case 8:
                    args.Title = "TLJ";
                    args.ReleaseDate = "December 15 2017";
                    break;
                case 9:
                    args.Title = "IX";
                    args.ReleaseDate = "December 20 2019";
                    break;
                default:
                    args.Title = "No Match, perhaps you were looking for one of the non-episode movies?";
                    args.ReleaseDate = "The first non-episode film was released on November 25 1984";
                    break;
            }

            OnmyEvent(args);
        }

        protected virtual void OnmyEvent(TestEventArgs _args)
        {
            //CrestronConsole.PrintLine("Protected OnMyTest: {0}", _args.Title);
            myEvent(this, _args); //call the event
        }
         
    }
}
