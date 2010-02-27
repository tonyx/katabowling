using System;
using System.Diagnostics;

namespace ocpBowling
{
// Design By Contract Checks.
// 
// Each method generates an exception or
// a Trace assertion if the contract is broken.
//
// If you wish to use Trace statements rather than exception han
// dling then call the methods ending in Trace
// e.g., Check.RequireTrace(a > 1, "a must be > 1");
// Then output will be directed to a Trace listener. For example, you could insert
//
// Trace.Listeners.Clear();
// Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
// 
    public sealed class Check
    {
// No creation
        private Check()
        {
        }

        [Conditional("DBC_CHECK_ALL"),
         Conditional("DBC_CHECK_INVARIANT"),
         Conditional("DBC_CHECK_POSTCONDITION"),
         Conditional("DBC_CHECK_PRECONDITION")]
        public static void Require(bool assertion, string message)
        {
            if (!assertion) throw new PreconditionException(message);
        }

        [Conditional("DBC_CHECK_ALL"),
         Conditional("DBC_CHECK_INVARIANT"),
         Conditional("DBC_CHECK_POSTCONDITION"),
         Conditional("DBC_CHECK_PRECONDITION")]
        public static void Require(bool assertion, string message, Exception inner)
        {
            if (!assertion) throw new PreconditionException(message, inner);
        }

        [Conditional("DBC_CHECK_ALL"),
         Conditional("DBC_CHECK_INVARIANT"),
         Conditional("DBC_CHECK_POSTCONDITION"),
         Conditional("DBC_CHECK_PRECONDITION")]
        public static void Require(bool assertion)
        {
            if (!assertion) throw new PreconditionException();
        }

        [Conditional("DBC_CHECK_ALL"),
         Conditional("DBC_CHECK_INVARIANT"),
         Conditional("DBC_CHECK_POSTCONDITION")]
        public static void Ensure(bool assertion, string message)
        {
            if (!assertion) throw new PostconditionException(message);
        }

        [Conditional("DBC_CHECK_ALL"),
         Conditional("DBC_CHECK_INVARIANT"),
         Conditional("DBC_CHECK_POSTCONDITION")]
        public static void Ensure(bool assertion, string message, Exception inner)
        {
            if (!assertion) throw new PostconditionException(message, inner);
        }

        [Conditional("DBC_CHECK_ALL"),
         Conditional("DBC_CHECK_INVARIANT"),
         Conditional("DBC_CHECK_POSTCONDITION")]
        public static void Ensure(bool assertion)
        {
            if (!assertion) throw new PostconditionException();
        }

        [Conditional("DBC_CHECK_ALL"),
         Conditional("DBC_CHECK_INVARIANT")]
        public static void Invariant(bool assertion, string message)
        {
            if (!assertion) throw new InvariantException(message);
        }

        [Conditional("DBC_CHECK_ALL"),
         Conditional("DBC_CHECK_INVARIANT")]
        public static void Invariant(bool assertion, string message, Exception inner)
        {
            if (!assertion) throw new InvariantException(message, inner);
        }

        [Conditional("DBC_CHECK_ALL"),
         Conditional("DBC_CHECK_INVARIANT")]
        public static void Invariant(bool assertion)
        {
            if (!assertion) throw new InvariantException();
        }

        [Conditional("DBC_CHECK_ALL")]
        public static void Assert(bool assertion, string message)
        {
            if (!assertion) throw new AssertionException(message);
        }

        [Conditional("DBC_CHECK_ALL")]
        public static void Assert(bool assertion)
        {
            if (!assertion) throw new AssertionException();
        }

        [Conditional("DBC_CHECK_ALL"),
         Conditional("DBC_CHECK_INVARIANT"),
         Conditional("DBC_CHECK_POSTCONDITION"),
         Conditional("DBC_CHECK_PRECONDITION")]
        public static void RequireTrace(bool assertion, string message)
        {
            Trace.Assert(assertion, "Precondition: " + message);
        }

        [Conditional("DBC_CHECK_ALL"),
         Conditional("DBC_CHECK_INVARIANT"),
         Conditional("DBC_CHECK_POSTCONDITION"),
         Conditional("DBC_CHECK_PRECONDITION")]
        public static void RequireTrace(bool assertion)
        {
            Trace.Assert(assertion, "Precondition failed.");
        }

        [Conditional("DBC_CHECK_ALL"),
         Conditional("DBC_CHECK_INVARIANT"),
         Conditional("DBC_CHECK_POSTCONDITION")]
        public static void EnsureTrace(bool assertion, string message)
        {
            Trace.Assert(assertion, "Postcondition: " + message);
        }

        [Conditional("DBC_CHECK_ALL"),
         Conditional("DBC_CHECK_INVARIANT"),
         Conditional("DBC_CHECK_POSTCONDITION")]
        public static void EnsureTrace(bool assertion)
        {
            Trace.Assert(assertion, "Postcondition failed.");
        }

        [Conditional("DBC_CHECK_ALL"),
         Conditional("DBC_CHECK_INVARIANT")]
        public static void InvariantTrace(bool assertion, string message)
        {
            Trace.Assert(assertion, "Invariant: " + message);
        }

        [Conditional("DBC_CHECK_ALL"),
         Conditional("DBC_CHECK_INVARIANT")]
        public static void InvariantTrace(bool assertion)
        {
            Trace.Assert(assertion, "Invariant failed.");
        }

        [Conditional("DBC_CHECK_ALL")]
        public static void AssertTrace(bool assertion, string message)
        {
            Trace.Assert(assertion, "Assertion: " + message);
        }

        [Conditional("DBC_CHECK_ALL")]
        public static void AssertTrace(bool assertion)
        {
            Trace.Assert(assertion, "Assertion failed.");
        }
    }

    // End Check

// Exception Classes

    public class AssertionException : System.ApplicationException
    {
        public AssertionException()
        {
        }

        public AssertionException(string message) : base(message)
        {
        }

        public AssertionException(string message, Exception inner) : base(message, inner)
        {
        }
    }

    public class PreconditionException : System.ApplicationException
    {
        public PreconditionException()
        {
        }

        public PreconditionException(string message) : base(message)
        {
        }

        public PreconditionException(string message, Exception inner) : base(message, inner)
        {
        }
    }

    public class PostconditionException : System.ApplicationException
    {
        public PostconditionException()
        {
        }

        public PostconditionException(string message) : base(message)
        {
        }

        public PostconditionException(string message, Exception inner) : base(message, inner)
        {
        }
    }

    public class InvariantException : System.ApplicationException
    {
        public InvariantException()
        {
        }

        public InvariantException(string message) : base(message)
        {
        }

        public InvariantException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}

// End Design By Contract