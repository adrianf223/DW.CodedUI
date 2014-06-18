using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("DW.CodedUI - Test your UI fast and easy")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyProduct("DW.CodedUI")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: Guid("2fd82625-aa9a-4bf6-b260-60afb89647e7")]

[assembly: InternalsVisibleTo("DW.CodedUI.Tests")]

/*
 * For InternalsVisibleto
 * - Sign the test project with the same key
 * - Extract public key from it (sn -p my-libraries.pfx my-libraries.pub)
 * - Show public key (sn -tp my-libraries.pub
 * - Add the key on one line into the PublicKey= of the InternalsVisibleTo (See above)
 * */
