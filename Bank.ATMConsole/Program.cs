using Bank.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.ATMConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string art = @"
                        ,,JAMNB&L=,.
                     ,;6BNMMWBEHBEM&L,.
                  ,;NMHKFY=:-:\*I*JIWMB\
                 /JMBGSF;:'..,-:;:-;+TZMA
                /GMNZPI;-,...,,-:;:\:»JBMA.
               ;AMNWGY+:-,...,,,-;=\;'ILBMB,
              .AMEHBBZ«;-:-.,.,,-:+\=+JIENMA
             ,JMHMSNFI*«:-,....,.;\+»*JYEBHML
            /AMWNBHXZL«::-,,....,\:+;IJHEBMN
            HMWNMMMBGJ*\:,./JV6&5ZL*8/AVEBWBF&
            ZWKARHMEXY+--;JAGEBWMNAHW»MMMNMEWM&
           ,HBHDSWNMHTI:-/+SJBAHBH=\.GMWFTMRHMB
         ,ANMNXBHWMNAC*:/JSPCMS*R+:;.YMLMNTMKNM
        ANMWMMBMHMBNCI=:.,-\-«+ZF,-\.*MZF6EMAMB
       ;IMSBWMWENMMZVI\-..:;\+7.,/;::.NSPVREIMB
       IMDHPNANMMMNELI=\:::;\;:;JI//.,*MPIJNIMW&
      ;NWEFLTEMEMAMZLJI*+=\+=«/IJ+OWMNAWMWJIPYMMNB
     JBEHAGDXWMMKITJTZJ*=**=*«F:-*T«MWNMMTLMIMNEM&
     OMEHEHWENMMGTIAVIJII***JTLOL*/IVIMMKZOMIMMNBB
     IMEBEWNBWMMMMNEZCL&VJ*IZR*TSPEZBWNMNKRMHMWMME
    6NMEMNWNMBMMMMHWFJ&TIIJIJ*«:--:;I*ZMMEBIMNMNMF
    CBNMMWMBMMWNMMOHFTJLJIIJI+*\=JFAHGENBHMAMMNBW'
    INMMNMWMNWMNMN+DJPLJYCLV&I*+;\:\I+LZH=AMNWMNF
    IIBNMNMNMNMMNM\\*&FLTFTFDOCTJIIJOZHM+NMMNNBY
    1'YMNMWNMNMNXGA.-.:YF&AZYZGOAWHEBNM=RMMRYP':
    ' 'IMWMBMNNXZOPO,\.-YFEKERWNMNMMMAGPNMBI'
     ,JWKWWRZWAEBHFT&-.,\.YEBWBBNMMMMMNZO'KR
  ,JGAGHRZYQHEXHRSF&PO\,\,.\TMNMMMNMMYMN&»''
./T&FZYDSROPOSDGRKEBFTTRS-\,:\YWRWNMFANHMNWL,
.:JLYJJZLCSDFZOPDAXHGXETLAD:.\+JOZDRBMEMNMMWB&,
..:;\+IJF&RFZOLPKFRHAGHZFZKXD:\*KAQNEMHNMMMMMWBA.
 .,:;»*IOZTBPGVCHZEAH&SNHZTLZWSRTZPCLZF;,7JWMNMBMA;.
  .,-:;»IPOZBFALZEZDEKNDBBNKEOJIN&TOKA5:.,Y:YMMNMWNEA;.
    .,-:;\I&BOGCBZAGQMZHEWMBZOCWOPF&PAWP«JI;IFVMWMNEBKF.
      .,:=ITSLTIJWZWHEMKSEHBNLWM&ZYZGRIHHE**=*NMMNHZI;:.
       .,:;+ITIIJBFWHKMRKRERMBAXKBFT&FBNMWNI*NMMNBRF*:.
        .,:;=I+IIKLEAFNOTZPSAXEB=NWZZYDEWBNLJBEHWSI;.
          ..:;+«=VIITCHLTJFTOCE*TGBMC&TDKHWN*EZCLV*-.
            ..:;+\C«IOTIIJYT&TFKHENMEIIJFZDEWR+*=:.
              ..,,:;=;+\«**ILTLYJORZKI*JTCVIJI:,'
                  ..,.,:,:=;:;:;«+\*+\»\;:-,.";

            Console.WriteLine(art);
            var actServ = new AccountService();
            var custServ = new CustomerService();

            Console.WriteLine("\n\nWelcome to Ben Franklin Bank.\n" +
                "Please enter your account number.");
            string numInput = Console.ReadLine();
            var userAccount = actServ.GetAccount(numInput);
            var userCustomer = custServ.GetCustomer(userAccount.CustomerID);

            Console.WriteLine("Please enter your PIN.");
            string pinInput;
            bool pinVerified = false;

            do
            {
                pinInput = Console.ReadLine();

                if(custServ.Verify(pinInput, userCustomer))
                {
                    pinVerified = true;
                }

                else
                {
                    Console.WriteLine("PIN invalid; please try again.");
                }
            } while (pinVerified == false);

            Console.Clear();

            bool exit = false;

            Console.WriteLine($"Welcome, {userCustomer.FirstName}.");
            do
            {
                Console.WriteLine("What operation would you like to perform? \n" +
                $"1. Check balance \n" +
                $"2. Made deposit \n" +
                $"3. Make withdrawl \n" +
                $"4. Exit service");

                string menuInput = Console.ReadLine();

                switch (menuInput)
                {
                    case "1":
                        Console.WriteLine($"Current balance: {userAccount.Balance}");
                        break;

                    case "2":
                        Console.WriteLine("How much would you like to deposit?");
                        decimal depositInput = Decimal.Parse(Console.ReadLine());
                        new DepositService().Deposit(depositInput, userAccount);
                        Console.WriteLine("Deposit accepted.");
                        break;

                    case "3":
                        Console.WriteLine("How much would you like to withdraw?");
                        decimal withdrawInput = Decimal.Parse(Console.ReadLine());
                        if (withdrawInput > userAccount.Balance)
                        {
                            Console.WriteLine("Invalid amount; you were just saved from an overdraft.");
                        }

                        else
                        {
                            new WithdrawlService().Withdraw(withdrawInput, userAccount);
                            Console.WriteLine("Cash being dispensed.");
                        }
                        break;

                    case "4":
                        Console.WriteLine("Thank you for using Ben Franklin Bank!");
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }

                Thread.Sleep(5000);
                Console.Clear();
            } while (exit == false);

        }
    }
}
