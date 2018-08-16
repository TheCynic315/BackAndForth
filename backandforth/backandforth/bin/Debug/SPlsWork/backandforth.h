namespace backandforth;
        // class declarations
         class TestEventArgs;
         class CallBackTesting;
         class EventTesting;
     class TestEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Title[];
        STRING ReleaseDate[];
    };

     class CallBackTesting 
    {
        // class delegates
        delegate FUNCTION SimplPlusCallBack ( SIMPLSHARPSTRING s );

        // class events

        // class functions
        FUNCTION Setup ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        DelegateProperty SimplPlusCallBack HeySimplPlus;
    };

     class EventTesting 
    {
        // class delegates
        delegate FUNCTION SimplPlusCallBack ( SIMPLSHARPSTRING s );

        // class events

        // class functions
        FUNCTION Setup ();
        FUNCTION GetData ( INTEGER _id );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        STRING Name[];
        STRING Date[];

        // class properties
        DelegateProperty SimplPlusCallBack HeySimplPlus;
    };

