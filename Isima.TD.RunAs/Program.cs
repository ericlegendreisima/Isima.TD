using System;
using System.Security.Principal;
using Isima.TD.RunAs.Security;

namespace Isima.TD.RunAs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Domaine : ");
            string domain = Console.ReadLine();

            Console.Write("Identifiant : ");
            string username = Console.ReadLine();

            Console.Write("Mot de passe : ");
            Console.ForegroundColor = ConsoleColor.Black;
            string password = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            ImpersonateUser(username, domain, password);
        }

        private static void ImpersonateUser(string username, string domain, string password)
        {
            try
            {
                IntPtr hToken = IntPtr.Zero;
                IntPtr hTokenDuplicate = IntPtr.Zero;

                if (NativeMethods.LogonUser(username, domain, password, (uint)NativeMethods.LogonType.LOGON32_LOGON_INTERACTIVE, (uint)NativeMethods.LogonProvider.LOGON32_PROVIDER_DEFAULT, out hToken))
                {
                    if (NativeMethods.DuplicateToken(hToken, 2, ref hTokenDuplicate))
                    {
                        WindowsIdentity windowsIdentity = new WindowsIdentity(hTokenDuplicate);
                        using (WindowsImpersonationContext impersonationContext = windowsIdentity.Impersonate())
                        {
                            Console.WriteLine("Le contexte de sécurité a été changé pour {0}", WindowsIdentity.GetCurrent().Name);

                            impersonationContext.Undo();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Authentication failed for {0}\\{1}.", domain, username);
                }

                if (hToken != IntPtr.Zero) NativeMethods.CloseHandle(hToken);
                if (hTokenDuplicate != IntPtr.Zero) NativeMethods.CloseHandle(hTokenDuplicate);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("An error occurred: {0}", ex);
            }
        }
    }
}
