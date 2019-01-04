using SailawayToNMEA.Model;
using System;
***REMOVED***
***REMOVED***
***REMOVED***
***REMOVED***

***REMOVED***
***REMOVED***
    public sealed class Global
    ***REMOVED***
        private static readonly Lazy<Global> lazy = new Lazy<Global>(() => new Global());

        public static Global Instance ***REMOVED*** get ***REMOVED*** return lazy.Value; ***REMOVED*** ***REMOVED***

        private Global()
        ***REMOVED***

    ***REMOVED***

        public List<BoatInfo> Boats ***REMOVED*** get; set; ***REMOVED***
***REMOVED***
***REMOVED***
