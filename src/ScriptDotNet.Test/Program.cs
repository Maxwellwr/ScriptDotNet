using Microsoft.Extensions.DependencyInjection;
using ScriptDotNet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int GetPortFromCommandLineArgs()
            {
                if (args.Length > 1 && int.TryParse(args[1], out var p) && p > 50908 && p < 52000)
                    return p;
                return 0;
            }

            int port = GetPortFromCommandLineArgs();

            IServiceCollection services = new ServiceCollection();
            services.AddScriptDotNet(port);
            var serviceProvider = services.BuildServiceProvider();

            var stealth = serviceProvider.GetRequiredService<Stealth>();
            var stealthService = serviceProvider.GetService<IStealthService>();
            Console.WriteLine(stealthService.StealthInfo.StealthVersion);

            var eventSystem = serviceProvider.GetService<IEventSystemService>();
            //eventSystem.AddItemToContainer += (o, e) => Console.WriteLine("AddItemToContainer " + e.ItemId);
            //eventSystem.AddMultipleItemsInContainer += (o, e) => Console.WriteLine("AddMultipleItemsInContainer " + e.ContainerId);
            eventSystem.AllowRefuseAttack += (o, e) => Console.WriteLine("AllowRefuseAttack " + e.IsAttackOK);
            eventSystem.Buff_DebuffSystem += (o, e) => Console.WriteLine("Buff_DebuffSystem " + e.AttributeId);
            //eventSystem.CharAnimation += (o, e) => Console.WriteLine("CharAnimation " + e.Action);
            eventSystem.ClientSendResync += (o, e) => Console.WriteLine("ClientSendResync " + "resync");
            //eventSystem.ClilocSpeech += (o, e) => Console.WriteLine("ClilocSpeech " + e.Text);
            eventSystem.ClilocSpeechAffix += (o, e) => Console.WriteLine("ClilocSpeechAffix " + e.Text);
            eventSystem.Death += (o, e) => Console.WriteLine("Death " + e.IsDead);
            //eventSystem.DrawContainer += (o, e) => Console.WriteLine("DrawContainer " + e.ModelGump);
            eventSystem.DrawGamePlayer += (o, e) => Console.WriteLine("DrawGamePlayer " + e.ObjectId);
            //eventSystem.DrawObject += (o, e) => Console.WriteLine("DrawObject " + e.ObjectId);
            eventSystem.GraphicalEffect += (o, e) => Console.WriteLine("GraphicalEffect " + e.ItemId);
            eventSystem.GumpTextEntry += (o, e) => Console.WriteLine("GumpTextEntry " + e.Title);
            eventSystem.IncomingGump += (o, e) => Console.WriteLine("IncomingGump " + e.GumpId);
            //eventSystem.ItemDeleted += (o, e) => Console.WriteLine("ItemDeleted " + e.ItemId);
            //eventSystem.ItemInfo += (o, e) => Console.WriteLine("ItemInfo " + e.ItemId);
            eventSystem.MapMessage += (o, e) => Console.WriteLine("MapMessage " + e.ItemId);
            eventSystem.MapPin += (o, e) => Console.WriteLine("MapPin " + e.PinId);
            eventSystem.Menu += (o, e) => Console.WriteLine("Menu " + e.MenuId);
            eventSystem.MoveRejection += (o, e) => Console.WriteLine("MoveRejection " + e.Direction);
            eventSystem.PartyInvite += (o, e) => Console.WriteLine("PartyInvite " + e.InviterId);
            eventSystem.QuestArrow += (o, e) => Console.WriteLine("QuestArrow " + e.IsActive);
            eventSystem.WindowsMessage += (o, e) => Console.WriteLine("WindowsMessage " + e.LParam);
            eventSystem.Speech += (o, e) => Console.WriteLine("Speech " + e.Text);
            eventSystem.UnicodeSpeech += (o, e) => Console.WriteLine("UnicodeSpeech " + e.Text);

            ConsoleKey key;
            do
            {
                key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.Backspace:
                        break;
                    case ConsoleKey.Tab:
                        break;
                    case ConsoleKey.Clear:
                        break;
                    case ConsoleKey.Enter:
                        break;
                    case ConsoleKey.Pause:
                        break;
                    case ConsoleKey.Escape:
                        break;
                    case ConsoleKey.Spacebar:
                        break;
                    case ConsoleKey.PageUp:
                        break;
                    case ConsoleKey.PageDown:
                        break;
                    case ConsoleKey.End:
                        break;
                    case ConsoleKey.Home:
                        break;
                    case ConsoleKey.LeftArrow:
                        break;
                    case ConsoleKey.UpArrow:
                        break;
                    case ConsoleKey.RightArrow:
                        break;
                    case ConsoleKey.DownArrow:
                        break;
                    case ConsoleKey.Select:
                        break;
                    case ConsoleKey.Print:
                        break;
                    case ConsoleKey.Execute:
                        break;
                    case ConsoleKey.PrintScreen:
                        break;
                    case ConsoleKey.Insert:
                        break;
                    case ConsoleKey.Delete:
                        break;
                    case ConsoleKey.Help:
                        break;
                    case ConsoleKey.D0:
                        break;
                    case ConsoleKey.D1:
                        break;
                    case ConsoleKey.D2:
                        break;
                    case ConsoleKey.D3:
                        break;
                    case ConsoleKey.D4:
                        break;
                    case ConsoleKey.D5:
                        break;
                    case ConsoleKey.D6:
                        break;
                    case ConsoleKey.D7:
                        break;
                    case ConsoleKey.D8:
                        break;
                    case ConsoleKey.D9:
                        break;
                    case ConsoleKey.A:
                        uint objId = 0x0000C251;
                        stealth.Target.WaitTargetObject(objId);
                        stealth.SkillSpell.UseSkill(Skills.Anatomy);
                        break;
                    case ConsoleKey.B:
                        break;
                    case ConsoleKey.C:
                        break;
                    case ConsoleKey.D:
                        break;
                    case ConsoleKey.E:
                        break;
                    case ConsoleKey.F:
                        break;
                    case ConsoleKey.G:
                        break;
                    case ConsoleKey.H:
                        break;
                    case ConsoleKey.I:
                        break;
                    case ConsoleKey.J:
                        break;
                    case ConsoleKey.K:
                        break;
                    case ConsoleKey.L:
                        break;
                    case ConsoleKey.M:
                        break;
                    case ConsoleKey.N:
                        break;
                    case ConsoleKey.O:
                        break;
                    case ConsoleKey.P:
                        break;
                    case ConsoleKey.Q:
                        break;
                    case ConsoleKey.R:
                        break;
                    case ConsoleKey.S:
                        break;
                    case ConsoleKey.T:
                        break;
                    case ConsoleKey.U:
                        break;
                    case ConsoleKey.V:
                        break;
                    case ConsoleKey.W:
                        break;
                    case ConsoleKey.X:
                        break;
                    case ConsoleKey.Y:
                        break;
                    case ConsoleKey.Z:
                        break;
                    case ConsoleKey.LeftWindows:
                        break;
                    case ConsoleKey.RightWindows:
                        break;
                    case ConsoleKey.Applications:
                        break;
                    case ConsoleKey.Sleep:
                        break;
                    case ConsoleKey.NumPad0:
                        break;
                    case ConsoleKey.NumPad1:
                        break;
                    case ConsoleKey.NumPad2:
                        break;
                    case ConsoleKey.NumPad3:
                        break;
                    case ConsoleKey.NumPad4:
                        break;
                    case ConsoleKey.NumPad5:
                        break;
                    case ConsoleKey.NumPad6:
                        break;
                    case ConsoleKey.NumPad7:
                        break;
                    case ConsoleKey.NumPad8:
                        break;
                    case ConsoleKey.NumPad9:
                        break;
                    case ConsoleKey.Multiply:
                        break;
                    case ConsoleKey.Add:
                        break;
                    case ConsoleKey.Separator:
                        break;
                    case ConsoleKey.Subtract:
                        break;
                    case ConsoleKey.Decimal:
                        break;
                    case ConsoleKey.Divide:
                        break;
                    case ConsoleKey.F1:
                        break;
                    case ConsoleKey.F2:
                        break;
                    case ConsoleKey.F3:
                        break;
                    case ConsoleKey.F4:
                        break;
                    case ConsoleKey.F5:
                        break;
                    case ConsoleKey.F6:
                        break;
                    case ConsoleKey.F7:
                        break;
                    case ConsoleKey.F8:
                        break;
                    case ConsoleKey.F9:
                        break;
                    case ConsoleKey.F10:
                        break;
                    case ConsoleKey.F11:
                        break;
                    case ConsoleKey.F12:
                        break;
                    case ConsoleKey.F13:
                        break;
                    case ConsoleKey.F14:
                        break;
                    case ConsoleKey.F15:
                        break;
                    case ConsoleKey.F16:
                        break;
                    case ConsoleKey.F17:
                        break;
                    case ConsoleKey.F18:
                        break;
                    case ConsoleKey.F19:
                        break;
                    case ConsoleKey.F20:
                        break;
                    case ConsoleKey.F21:
                        break;
                    case ConsoleKey.F22:
                        break;
                    case ConsoleKey.F23:
                        break;
                    case ConsoleKey.F24:
                        break;
                    case ConsoleKey.BrowserBack:
                        break;
                    case ConsoleKey.BrowserForward:
                        break;
                    case ConsoleKey.BrowserRefresh:
                        break;
                    case ConsoleKey.BrowserStop:
                        break;
                    case ConsoleKey.BrowserSearch:
                        break;
                    case ConsoleKey.BrowserFavorites:
                        break;
                    case ConsoleKey.BrowserHome:
                        break;
                    case ConsoleKey.VolumeMute:
                        break;
                    case ConsoleKey.VolumeDown:
                        break;
                    case ConsoleKey.VolumeUp:
                        break;
                    case ConsoleKey.MediaNext:
                        break;
                    case ConsoleKey.MediaPrevious:
                        break;
                    case ConsoleKey.MediaStop:
                        break;
                    case ConsoleKey.MediaPlay:
                        break;
                    case ConsoleKey.LaunchMail:
                        break;
                    case ConsoleKey.LaunchMediaSelect:
                        break;
                    case ConsoleKey.LaunchApp1:
                        break;
                    case ConsoleKey.LaunchApp2:
                        break;
                    case ConsoleKey.Oem1:
                        break;
                    case ConsoleKey.OemPlus:
                        break;
                    case ConsoleKey.OemComma:
                        break;
                    case ConsoleKey.OemMinus:
                        break;
                    case ConsoleKey.OemPeriod:
                        break;
                    case ConsoleKey.Oem2:
                        break;
                    case ConsoleKey.Oem3:
                        break;
                    case ConsoleKey.Oem4:
                        break;
                    case ConsoleKey.Oem5:
                        break;
                    case ConsoleKey.Oem6:
                        break;
                    case ConsoleKey.Oem7:
                        break;
                    case ConsoleKey.Oem8:
                        break;
                    case ConsoleKey.Oem102:
                        break;
                    case ConsoleKey.Process:
                        break;
                    case ConsoleKey.Packet:
                        break;
                    case ConsoleKey.Attention:
                        break;
                    case ConsoleKey.CrSel:
                        break;
                    case ConsoleKey.ExSel:
                        break;
                    case ConsoleKey.EraseEndOfFile:
                        break;
                    case ConsoleKey.Play:
                        break;
                    case ConsoleKey.Zoom:
                        break;
                    case ConsoleKey.NoName:
                        break;
                    case ConsoleKey.Pa1:
                        break;
                    case ConsoleKey.OemClear:
                        break;
                    default:
                        break;
                }
            }
            while (key != ConsoleKey.Escape);

        }

    }
}
