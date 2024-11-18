using System;
using System.Management;
using System.Diagnostics;
using System.Threading;
using System.Linq;
using System.IO;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace PafishLike
{



    class Program
    {
        


        static bool IsMiniMode = false;
        static bool IsLogEnabled = false;
        static StreamWriter logWriter;


        static void Main(string[] args)
        {

            if (args.Contains("--mini"))
            {
                IsMiniMode = true;
            }

            if (args.Contains("--help"))
            {
                PrintHelp();
                return;
            }


            if (args.Contains("--log"))
            {
                IsLogEnabled = true;
                logWriter = new StreamWriter("info.log", append: true); // Öffne (oder erstelle) die Log-Datei
                logWriter.WriteLine($"Log started at {DateTime.Now}");
                Log("Log started");  // Nachricht an Log() übergeben
            }





            // Begrüßungsnachricht
            Console.WriteLine("VM Detection");
            Console.WriteLine("-------------------------\n");
            Console.WriteLine("██╗   ██╗███╗   ███╗    ██████╗ ███████╗████████╗███████╗ ██████╗████████╗ ██████╗ ██████╗ \r\n██║   ██║████╗ ████║    ██╔══██╗██╔════╝╚══██╔══╝██╔════╝██╔════╝╚══██╔══╝██╔═══██╗██╔══██╗\r\n██║   ██║██╔████╔██║    ██║  ██║█████╗     ██║   █████╗  ██║        ██║   ██║   ██║██████╔╝\r\n╚██╗ ██╔╝██║╚██╔╝██║    ██║  ██║██╔══╝     ██║   ██╔══╝  ██║        ██║   ██║   ██║██╔══██╗\r\n ╚████╔╝ ██║ ╚═╝ ██║    ██████╔╝███████╗   ██║   ███████╗╚██████╗   ██║   ╚██████╔╝██║  ██║\r\n  ╚═══╝  ╚═╝     ╚═╝    ╚═════╝ ╚══════╝   ╚═╝   ╚══════╝ ╚═════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝\r\n                                                                                           ");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("\nOptions:\n\nD Detect This PC.\n\nT Remove VM traces (can be dangerous, im not responsible for any damages)");
            // Hier beginnt die VM-Erkennu
            MonitorUserInputOnStart();
            







            // Abschlussmeldung
            Console.WriteLine("\nDetection completed.");
            Console.WriteLine("\nOptions:\n\nR Clear the Console and run the checks again.\n\nE Exit the Detection");
            MonitorUserInput();
            Console.ReadLine();



        }















        


        static void MonitorUserInput()
        {
            bool running = true;
            while (running)
            {
                var key = Console.ReadKey(intercept: true).Key; // Tasteneingabe überwachen

                switch (key)
                {
                    case ConsoleKey.R:
                        // Konsole löschen und VM-Diagnose erneut starten
                        CheckBiosInformation();
                        CheckMacAddresses();
                        CheckRegistryKeys();
                        CheckUserDirectory();
                        CheckProcessesAndServices();
                        CheckCpuInformation();
                        CheckCpuTiming();
                        CheckDiskInformation();
                        CheckMouseMovements();
                        CheckGpu3DPerformance();
                        CheckRamSize();
                        CheckCpuCoreCount();
                        CheckHostName();
                        CheckNestedVirtualization();
                        CheckBootTime();
                        CheckDrivers();
                        CheckHardwareManufacturer();
                        CheckHardwareIds();
                        CheckScreensaver();
                        CheckVirtualNetworkAdapters();
                        CheckWMIErrors();
                        Console.WriteLine("\nDetection completed.");
                        Console.WriteLine("\nOptions:\n\nR Clear the Console and run the checks again.\n\nE Exit the Detection");
                        MonitorUserInput();
                        Console.ReadLine();
                        break;

                    case ConsoleKey.E:
                        // Anwendung beenden
                        Log("Exiting application.");
                        if (IsLogEnabled)
                        {
                            logWriter.WriteLine($"Log ended at {DateTime.Now}");
                            logWriter.Close();  // Log-Datei schließen
                        }
                        Environment.Exit(0);
                        break;

                    case ConsoleKey.S:
                        // Alle Konsolenausgaben in die Log-Datei speichern
                        SaveConsoleToLog();
                        break;

                    default:
                        // Keine Aktion für andere Tasten
                        break;
                }
            }
        }




        static void MonitorUserInputOnStart()
        {
            bool running = true;
            while (running)
            {
                var key = Console.ReadKey(intercept: true).Key; // Tasteneingabe überwachen

                switch (key)
                {
                    case ConsoleKey.D:
                        // Konsole löschen und VM-Diagnose erneut starten
                        Console.Clear();
                        Log("Console cleared.");
                        // Hier beginnt die VM-Erkennung
                        CheckBiosInformation();
                        CheckMacAddresses();
                        CheckRegistryKeys();
                        CheckUserDirectory();
                        CheckProcessesAndServices();
                        CheckCpuInformation();
                        CheckCpuTiming();
                        CheckDiskInformation();
                        CheckMouseMovements();
                        CheckGpu3DPerformance();
                        CheckRamSize();
                        CheckCpuCoreCount();
                        CheckHostName();
                        CheckNestedVirtualization();
                        CheckBootTime();
                        CheckDrivers();
                        CheckHardwareManufacturer();
                        CheckHardwareIds();
                        CheckScreensaver();
                        CheckVirtualNetworkAdapters();
                        CheckWMIErrors();
                        Console.WriteLine("\nDetection completed.");
                        Console.WriteLine("\nOptions:\n\nR Clear the Console and run the checks again.\n\nE Exit the Detection");
                        MonitorUserInput();
                        Console.ReadLine();
                        break;

                    case ConsoleKey.T:
                        // Anwendung beenden
                        WarningTraces();
                        break;


                    default:
                        // Keine Aktion für andere Tasten
                        break;
                }
            }
        }



        static void WarningTraces()
        {
            bool running = true;

            while (running)
            {
                var key = Console.ReadKey(intercept: true).Key; // Tasteneingabe überwachen
                Console.WriteLine("\nAre You realy shure to remove traces if yes click C! This can be dangerous, im not responsible for any damages!");
                switch (key)
                {
                    case ConsoleKey.C:
                        // 1. Treiber entfernen
                        RemoveDriver("vmmouse.sys");
                        RemoveDriver("vmhgfs.sys");
                        RemoveDriver("vm3dmp.sys");
                        RemoveDriver("VBoxMouse.sys");
                        RemoveDriver("VBoxSF.sys");
                        RemoveDriver("VBoxGuest.sys");

                        // 2. Autostart-Einträge in der Registry entfernen
                        RemoveDriverRegistryEntries("vmmouse");
                        RemoveDriverRegistryEntries("vmhgfs");
                        RemoveDriverRegistryEntries("vm3dmp");
                        RemoveDriverRegistryEntries("VBoxMouse");
                        RemoveDriverRegistryEntries("VBoxSF");
                        RemoveDriverRegistryEntries("VBoxGuest");

                        Console.WriteLine("drivers removed.");
                        Console.WriteLine("Reboot required.");
                        running = false; // Beendet die Schleife und damit das Programm
                        break;

                    default:
                        // Keine Aktion für andere Tasten
                        break;
                }
            }
        }



        static void SaveConsoleToLog()
        {
            try
            {
                if (IsLogEnabled)
                {
                    // Speichere den gesamten Konsoleninhalt in der Log-Datei
                    string consoleOutput = Console.Out.ToString();
                    logWriter.WriteLine("\nConsole Output saved:");
                    logWriter.WriteLine(consoleOutput);
                    logWriter.Flush();
                    Console.WriteLine("Console content saved to info.log.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving console output to log: {ex.Message}");
            }
        }

        static void Log(string message)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logMessage = $"[{timestamp}] {message}";

            if (IsLogEnabled)
            {
                try
                {
                    logWriter.WriteLine(logMessage);  // Schreibe die Nachricht in die Log-Datei
                    logWriter.Flush();  // Sofortiges Schreiben sicherstellen
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error writing to log file: {ex.Message}");
                }
            }

            Console.WriteLine(logMessage);  // Schreibe die Nachricht auch in die Konsole
        }


        static void CheckBiosInformation()
        {
            Console.WriteLine("\nChecking BIOS Information...");
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS");

                foreach (ManagementObject obj in searcher.Get())
                {
                    string manufacturer = obj["Manufacturer"]?.ToString() ?? "Unknown";
                    string version = obj["Version"]?.ToString() ?? "Unknown";
                    string serialNumber = obj["SerialNumber"]?.ToString() ?? "Unknown";

                    Console.WriteLine($"BIOS Manufacturer: {manufacturer}");
                    Console.WriteLine($"BIOS Version: {version}");
                    Console.WriteLine($"BIOS Serial Number: {serialNumber}");

                    if (serialNumber.Contains("VMware") || manufacturer.Contains("VirtualBox"))
                    {
                        SetConsoleColor(ConsoleColor.Red);
                        Console.WriteLine("VM detected based on BIOS information.");
                        ResetConsoleColor();
                    }
                    else
                    {
                        SetConsoleColor(ConsoleColor.Green);
                        Console.WriteLine("No VM detected based on BIOS information.");
                        ResetConsoleColor();
                    }
                }
            }
            catch (Exception ex)
            {
                SetConsoleColor(ConsoleColor.Yellow);
                Console.WriteLine($"Error checking BIOS information: {ex.Message}");
                ResetConsoleColor();
            }
        }






        static void PrintHelp()
        {
            Console.WriteLine("Usage: MyProgram [--mini]");
            Console.WriteLine("Options:");
            Console.WriteLine("  --mini   Display minimal output.");
        }


        static void CheckMacAddresses()
        {
            Console.WriteLine("\nChecking MAC Addresses...");
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapter");

                foreach (ManagementObject obj in searcher.Get())
                {
                    string macAddress = obj["MACAddress"]?.ToString() ?? "Unknown";


                    if (macAddress.Contains("00:0C:29") || macAddress.Contains("00:50:56"))
                    {
                        SetConsoleColor(ConsoleColor.Red);
                        Console.WriteLine("VM detected based on MAC address.");
                        ResetConsoleColor();
                    }
                    else
                    {
                        SetConsoleColor(ConsoleColor.Green);
                        Console.WriteLine("No VM detected based on MAC address.");
                        ResetConsoleColor();
                    }
                }
            }
            catch (Exception ex)
            {
                SetConsoleColor(ConsoleColor.Yellow);
                Console.WriteLine($"Error checking MAC addresses: {ex.Message}");
                ResetConsoleColor();
            }
        }



        static void CheckBootTime()
        {
            Console.WriteLine("\nChecking System Boot Time...");
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");

                foreach (ManagementObject obj in searcher.Get())
                {
                    DateTime lastBootTime = ManagementDateTimeConverter.ToDateTime(obj["LastBootUpTime"].ToString());
                    TimeSpan uptime = DateTime.Now - lastBootTime;

                    Console.WriteLine($"System Uptime: {uptime.TotalSeconds} seconds");

                    if (uptime.TotalSeconds < 600) // Weniger als 10 Minuten Uptime
                    {
                        SetConsoleColor(ConsoleColor.Red);
                        Console.WriteLine("Short uptime detected. Likely a VM.");
                        ResetConsoleColor();
                    }
                    else
                    {
                        SetConsoleColor(ConsoleColor.Green);
                        Console.WriteLine("Uptime appears normal.");
                        ResetConsoleColor();
                    }
                }
            }
            catch (Exception ex)
            {
                SetConsoleColor(ConsoleColor.Yellow);
                Console.WriteLine($"Error checking boot time: {ex.Message}");
                ResetConsoleColor();
            }
        }

        static void CheckRegistryKeys()
        {
            Console.WriteLine("\nChecking Registry Keys...");
            try
            {
                string[] registryKeys = new string[]
                {
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\VMware, Inc.\VMware Tools",
                    @"HKEY_LOCAL_MACHINE\SOFTWARE\Oracle\VirtualBox Guest Additions"
                };

                foreach (string registryKey in registryKeys)
                {
                    var key = Microsoft.Win32.Registry.GetValue(registryKey, "Install", null);
                    if (key != null)
                    {
                        SetConsoleColor(ConsoleColor.Red);
                        Console.WriteLine($"VM detected based on registry key: {registryKey}");
                        ResetConsoleColor();
                    }
                    else
                    {
                        SetConsoleColor(ConsoleColor.Green);
                        Console.WriteLine($"No VM detected based on registry key: {registryKey}");
                        ResetConsoleColor();
                    }
                }
            }
            catch (Exception ex)
            {
                SetConsoleColor(ConsoleColor.Yellow);
                Console.WriteLine($"Error checking registry keys: {ex.Message}");
                ResetConsoleColor();
            }
        }

        static void CheckProcessesAndServices()
        {
            Console.WriteLine("\nChecking Processes and Services...");
            try
            {
                string[] suspiciousProcesses = new string[]
                {
                    "vmtoolsd.exe",    // VMware Tools process
                    "VBoxService.exe"  // VirtualBox process
                };

                foreach (string processName in suspiciousProcesses)
                {
                    Process[] processes = Process.GetProcessesByName(processName);
                    if (processes.Length > 0)
                    {
                        SetConsoleColor(ConsoleColor.Red);
                        Console.WriteLine($"VM detected based on process: {processName}");
                        ResetConsoleColor();
                    }
                    else
                    {
                        SetConsoleColor(ConsoleColor.Green);
                        Console.WriteLine($"No VM detected based on process: {processName}");
                        ResetConsoleColor();
                    }
                }
            }
            catch (Exception ex)
            {
                SetConsoleColor(ConsoleColor.Yellow);
                Console.WriteLine($"Error checking processes and services: {ex.Message}");
                ResetConsoleColor();
            }
        }

        static void CheckCpuInformation()
        {
            Console.WriteLine("\nChecking CPU Information...");
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");

                foreach (ManagementObject obj in searcher.Get())
                {
                    string name = obj["Name"]?.ToString() ?? "Unknown";

                    Console.WriteLine($"CPU: {name}");

                    if (name.Contains("VMware") || name.Contains("VirtualBox"))
                    {
                        SetConsoleColor(ConsoleColor.Red);
                        Console.WriteLine("VM detected based on CPU information.");
                        ResetConsoleColor();
                    }
                    else
                    {
                        SetConsoleColor(ConsoleColor.Green);
                        Console.WriteLine("No VM detected based on CPU information.");
                        ResetConsoleColor();
                    }
                }
            }
            catch (Exception ex)
            {
                SetConsoleColor(ConsoleColor.Yellow);
                Console.WriteLine($"Error checking CPU information: {ex.Message}");
                ResetConsoleColor();
            }
        }

        static void CheckDiskInformation()
        {
            Console.WriteLine("\nChecking Disk Information...");
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

                foreach (ManagementObject obj in searcher.Get())
                {
                    string model = obj["Model"]?.ToString() ?? "Unknown";

                    Console.WriteLine($"Disk Model: {model}");

                    if (model.Contains("VMware") || model.Contains("VirtualBox"))
                    {
                        SetConsoleColor(ConsoleColor.Red);
                        Console.WriteLine("VM detected based on disk information.");
                        ResetConsoleColor();
                    }
                    else
                    {
                        SetConsoleColor(ConsoleColor.Green);
                        Console.WriteLine("No VM detected based on disk information.");
                        ResetConsoleColor();
                    }
                }
            }
            catch (Exception ex)
            {
                SetConsoleColor(ConsoleColor.Yellow);
                Console.WriteLine($"Error checking disk information: {ex.Message}");
                ResetConsoleColor();
            }
        }

        static void CheckMouseMovements()
        {
            Console.WriteLine("\nChecking Mouse Movements...");
            try
            {
                int x1 = 0, y1 = 0;
                int x2 = 100, y2 = 100;

                for (int i = 0; i < 5; i++)
                {
                    int newX = new Random().Next(0, 1920);
                    int newY = new Random().Next(0, 1080);

                    if (newX == x1 && newY == y1)
                    {
                        SetConsoleColor(ConsoleColor.Red);
                        Console.WriteLine("Mouse movement detected as suspicious (unlikely to move consistently in VM).");
                        ResetConsoleColor();
                    }
                    else
                    {
                        SetConsoleColor(ConsoleColor.Green);
                        Console.WriteLine("Mouse movement appears normal.");
                        ResetConsoleColor();
                    }

                    x1 = x2;
                    y1 = y2;
                    x2 = newX;
                    y2 = newY;
                }
            }
            catch (Exception ex)
            {
                SetConsoleColor(ConsoleColor.Yellow);
                Console.WriteLine($"Error checking mouse movements: {ex.Message}");
                ResetConsoleColor();
            }
        }

        static void CheckGpu3DPerformance()
        {
            Console.WriteLine("\nChecking GPU 3D performance...");
            bool found = false;

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");

                var videoControllers = searcher.Get();
                if (videoControllers.Count == 0)
                {
                    SetConsoleColor(ConsoleColor.Red);
                    Console.WriteLine("No video controller found.");
                    ResetConsoleColor();
                }
                else
                {
                    foreach (ManagementObject obj in videoControllers)
                    {
                        string gpuName = obj["Name"]?.ToString() ?? "Unknown";
                        bool supports3D = obj["Supports3D"] != null && (bool)obj["Supports3D"];

                        if (supports3D)
                        {
                            SetConsoleColor(ConsoleColor.Green);
                            Console.WriteLine($"GPU supports 3D: {gpuName}");
                            ResetConsoleColor();
                            found = true;
                        }
                        else
                        {
                            SetConsoleColor(ConsoleColor.Yellow);
                            Console.WriteLine($"GPU does not support 3D acceleration: {gpuName}");
                            ResetConsoleColor();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SetConsoleColor(ConsoleColor.Yellow);
                Console.WriteLine($"Error checking GPU 3D performance: {ex.Message}");
                ResetConsoleColor();
            }

            if (!found)
            {
                SetConsoleColor(ConsoleColor.Red);
                Console.WriteLine("No 3D GPU detected. Likely a VM environment.");
                ResetConsoleColor();
            }
        }




        static void CheckRamSize()
        {
            Console.WriteLine("\nChecking RAM Size...");
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");

                foreach (ManagementObject obj in searcher.Get())
                {
                    long totalPhysicalMemory = Convert.ToInt64(obj["TotalPhysicalMemory"]);
                    Console.WriteLine($"Total RAM: {totalPhysicalMemory / (1024 * 1024)} MB");

                    if (totalPhysicalMemory < 4L * 1024 * 1024 * 1024) // Weniger als 4GB
                    {
                        SetConsoleColor(ConsoleColor.Red);
                        Console.WriteLine("Suspiciously low RAM size. Likely a VM.");
                        ResetConsoleColor();
                    }
                    else
                    {
                        SetConsoleColor(ConsoleColor.Green);
                        Console.WriteLine("RAM size is normal.");
                        ResetConsoleColor();
                    }
                }
            }
            catch (Exception ex)
            {
                SetConsoleColor(ConsoleColor.Yellow);
                Console.WriteLine($"Error checking RAM size: {ex.Message}");
                ResetConsoleColor();
            }
        }

        static void CheckCpuCoreCount()
        {
            Console.WriteLine("\nChecking CPU Core Count...");
            try
            {
                int coreCount = Environment.ProcessorCount;
                Console.WriteLine($"CPU Core Count: {coreCount}");

                if (coreCount <= 2)
                {
                    SetConsoleColor(ConsoleColor.Red);
                    Console.WriteLine("Low core count detected. Likely a VM.");
                    ResetConsoleColor();
                }
                else
                {
                    SetConsoleColor(ConsoleColor.Green);
                    Console.WriteLine("CPU core count is normal.");
                    ResetConsoleColor();
                }
            }
            catch (Exception ex)
            {
                SetConsoleColor(ConsoleColor.Yellow);
                Console.WriteLine($"Error checking CPU core count: {ex.Message}");
                ResetConsoleColor();
            }
        }


        static void CheckDrivers()
        {
            string driversDirectory = @"C:\Windows\System32\drivers\";

            if (Directory.Exists(driversDirectory))
            {
                try
                {
                    // Liste alle Dateien im drivers-Verzeichnis
                    var driverFiles = Directory.GetFiles(driversDirectory);

                    bool vmDetected = false;

                    // Überprüfe, ob eine der gesuchten Dateien existiert
                    foreach (var file in driverFiles)
                    {
                        string fileName = Path.GetFileName(file).ToLower();

                        // Überprüfe auf spezifische Dateien und VM-Bezeichner im Dateinamen
                        if (fileName == "vmci.sys" || fileName == "vmenctl.sys" || fileName == "vboxmouse.sys" ||
                            fileName.Contains("vmware") || fileName.Contains("qemu") || fileName.Contains("vbox") || fileName.Contains("virtualbox"))
                        {
                            vmDetected = true;
                            Log($"VM-related driver detected: {fileName}");
                            break; // Beende die Schleife, wenn eine VM-Datei gefunden wurde
                        }
                    }

                    if (!vmDetected)
                    {
                        Log("No VM-related driver detected.");
                    }
                }
                catch (Exception ex)
                {
                    Log($"Error checking drivers: {ex.Message}");
                }
            }
            else
            {
                Log("Drivers directory does not exist.");
            }
        }



        static void CheckHardwareManufacturer()
        {
            Console.WriteLine("\nChecking Hardware Manufacturer...");
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");

                foreach (ManagementObject obj in searcher.Get())
                {
                    string manufacturer = obj["Manufacturer"]?.ToString() ?? "Unknown";

                    Console.WriteLine($"Manufacturer: {manufacturer}");

                    if (manufacturer.Contains("VMware") || manufacturer.Contains("VirtualBox") || manufacturer.Contains("QEMU"))
                    {
                        SetConsoleColor(ConsoleColor.Red);
                        Console.WriteLine("VM detected based on hardware manufacturer.");
                        ResetConsoleColor();
                    }
                    else
                    {
                        SetConsoleColor(ConsoleColor.Green);
                        Console.WriteLine("No VM detected based on hardware manufacturer.");
                        ResetConsoleColor();
                    }
                }
            }
            catch (Exception ex)
            {
                SetConsoleColor(ConsoleColor.Yellow);
                Console.WriteLine($"Error checking hardware manufacturer: {ex.Message}");
                ResetConsoleColor();
            }
        }



        static void CheckCpuTiming()
        {
            Console.WriteLine("\nChecking CPU Timing Anomalies...");
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                Thread.Sleep(100);
                stopwatch.Stop();

                Console.WriteLine($"Measured 100ms sleep: {stopwatch.ElapsedMilliseconds}ms");

                if (stopwatch.ElapsedMilliseconds < 90 || stopwatch.ElapsedMilliseconds > 110)
                {
                    SetConsoleColor(ConsoleColor.Red);
                    Console.WriteLine("CPU timing anomalies detected. Likely a VM.");
                    ResetConsoleColor();
                }
                else
                {
                    SetConsoleColor(ConsoleColor.Green);
                    Console.WriteLine("CPU timing appears normal.");
                    ResetConsoleColor();
                }
            }
            catch (Exception ex)
            {
                SetConsoleColor(ConsoleColor.Yellow);
                Console.WriteLine($"Error checking CPU timing: {ex.Message}");
                ResetConsoleColor();
            }
        }



        static void CheckHardwareIds()
        {
            Console.WriteLine("\nChecking Hardware IDs...");
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapter");

                foreach (ManagementObject obj in searcher.Get())
                {
                    string pnpDeviceId = obj["PNPDeviceID"]?.ToString() ?? "Unknown";

                    // Minimalistische Ausgabe
                    if (IsMiniMode)
                    {
                        if (pnpDeviceId.Contains("VEN_15AD") || pnpDeviceId.Contains("VEN_80EE")) // VMware und VirtualBox
                        {
                            SetConsoleColor(ConsoleColor.Red);
                            Console.WriteLine("VM detected based on PNP Device ID. {pnpDeviceId}");
                            ResetConsoleColor();
                        }
                        else
                        {
                            SetConsoleColor(ConsoleColor.Green);
                            Console.WriteLine("No VM detected based on PNP Device ID.");
                            ResetConsoleColor();
                        }
                    }
                    // Detaillierte Ausgabe
                    else
                    {
                        Console.WriteLine($"PNP Device ID: {pnpDeviceId}");

                        if (pnpDeviceId.Contains("VEN_15AD") || pnpDeviceId.Contains("VEN_80EE")) // VMware und VirtualBox
                        {
                            SetConsoleColor(ConsoleColor.Red);
                            Console.WriteLine("VM detected based on PNP Device ID.");
                            ResetConsoleColor();
                        }
                        else
                        {
                            SetConsoleColor(ConsoleColor.Green);
                            Console.WriteLine("No VM detected based on PNP Device ID.");
                            ResetConsoleColor();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SetConsoleColor(ConsoleColor.Yellow);
                Console.WriteLine($"Error checking hardware IDs: {ex.Message}");
                ResetConsoleColor();
            }
        }



        static void CheckScreensaver()
        {
            Console.WriteLine("\nChecking Screensaver Settings...");
            try
            {
                int screensaverTimeout = (int)Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Control Panel\Desktop", "ScreenSaveTimeOut", 0);
                Console.WriteLine($"Screensaver Timeout: {screensaverTimeout} seconds");

                if (screensaverTimeout == 0)
                {
                    SetConsoleColor(ConsoleColor.Red);
                    Console.WriteLine("No screensaver timeout detected. Could be a VM.");
                    ResetConsoleColor();
                }
                else
                {
                    SetConsoleColor(ConsoleColor.Green);
                    Console.WriteLine("Screensaver timeout appears normal.");
                    ResetConsoleColor();
                }
            }
            catch (Exception ex)
            {
                SetConsoleColor(ConsoleColor.Yellow);
                Console.WriteLine($"Error checking screensaver: {ex.Message}");
                ResetConsoleColor();
            }
        }


        static void CheckHostName()
        {
            Console.WriteLine("\nChecking Hostname...");
            try
            {
                string hostName = Environment.MachineName;
                Console.WriteLine($"Host Name: {hostName}");

                if (hostName.Contains("VM") || hostName.Contains("VBOX") || hostName.Contains("VIRTUAL"))
                {
                    SetConsoleColor(ConsoleColor.Red);
                    Console.WriteLine("VM detected based on hostname.");
                    ResetConsoleColor();
                }
                else
                {
                    SetConsoleColor(ConsoleColor.Green);
                    Console.WriteLine("No VM detected based on hostname.");
                    ResetConsoleColor();
                }
            }
            catch (Exception ex)
            {
                SetConsoleColor(ConsoleColor.Yellow);
                Console.WriteLine($"Error checking hostname: {ex.Message}");
                ResetConsoleColor();
            }
        }

        static void CheckNestedVirtualization()
        {
            Console.WriteLine("\nChecking Nested Virtualization...");
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");

                foreach (ManagementObject obj in searcher.Get())
                {
                    bool virtualizationFirmwareEnabled = obj["VirtualizationFirmwareEnabled"] != null &&
                                                         (bool)obj["VirtualizationFirmwareEnabled"];
                    Console.WriteLine($"Nested Virtualization Enabled: {virtualizationFirmwareEnabled}");

                    if (!virtualizationFirmwareEnabled)
                    {
                        SetConsoleColor(ConsoleColor.Red);
                        Console.WriteLine("Nested virtualization not supported. Likely a VM.");
                        ResetConsoleColor();
                    }
                    else
                    {
                        SetConsoleColor(ConsoleColor.Green);
                        Console.WriteLine("Nested virtualization supported.");
                        ResetConsoleColor();
                    }
                }
            }
            catch (Exception ex)
            {
                SetConsoleColor(ConsoleColor.Yellow);
                Console.WriteLine($"Error checking nested virtualization: {ex.Message}");
                ResetConsoleColor();
            }
        }

        static void CheckUserDirectory()
        {
            Console.WriteLine("\nChecking User Directory...");
            try
            {
                string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                Console.WriteLine($"User Profile Path: {userProfile}");

                if (userProfile.Contains("VM") || userProfile.Contains("VIRTUAL"))
                {
                    SetConsoleColor(ConsoleColor.Red);
                    Console.WriteLine("VM detected based on user directory path.");
                    ResetConsoleColor();
                }
                else
                {
                    SetConsoleColor(ConsoleColor.Green);
                    Console.WriteLine("No VM detected based on user directory path.");
                    ResetConsoleColor();
                }
            }
            catch (Exception ex)
            {
                SetConsoleColor(ConsoleColor.Yellow);
                Console.WriteLine($"Error checking user directory: {ex.Message}");
                ResetConsoleColor();
            }
        }



        static void CheckWMIErrors()
        {
            Console.WriteLine("\nChecking for WMI errors...");

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");

                foreach (ManagementObject obj in searcher.Get())
                {
                    string caption = obj["Caption"]?.ToString() ?? "Unknown";

                    Console.WriteLine($"Operating System: {caption}");

                    // Hier könnte auch nach Fehlern gesucht werden, die auf eine VM hinweisen
                    if (caption.Contains("VMware") || caption.Contains("VirtualBox"))
                    {
                        Console.WriteLine("WMI error detected, indicating possible virtual machine.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking WMI: {ex.Message}");
            }
        }





        static void CheckSystemInfo()
        {
            Console.WriteLine("\nChecking system information...");

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");

                foreach (ManagementObject obj in searcher.Get())
                {
                    string manufacturer = obj["Manufacturer"]?.ToString() ?? "Unknown";
                    string model = obj["Model"]?.ToString() ?? "Unknown";

                    Console.WriteLine($"System Manufacturer: {manufacturer}");
                    Console.WriteLine($"System Model: {model}");

                    if (manufacturer.Contains("VMware") || model.Contains("VirtualBox"))
                    {
                        Console.WriteLine("System appears to be running in a virtual machine.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking system information: {ex.Message}");
            }
        }



        static void CheckVirtualNetworkAdapters()
        {
            SetConsoleColor(ConsoleColor.Green);
            Console.WriteLine("\nChecking for virtual network adapters...");

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapter");

                foreach (ManagementObject obj in searcher.Get())
                {
                    string adapterName = obj["Name"]?.ToString() ?? "Unknown";
                    string adapterType = obj["AdapterType"]?.ToString() ?? "Unknown";
                    SetConsoleColor(ConsoleColor.Blue);
                    Console.WriteLine($"Network Adapter: {adapterName}, Type: {adapterType}");

                    // Prüfe nach typischen virtuellen Adapternamen
                    if (adapterName.Contains("VMware") || adapterName.Contains("VirtualBox"))
                    {
                        SetConsoleColor(ConsoleColor.Red);
                        Console.WriteLine("Virtual network adapter detected.");
                        ResetConsoleColor();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking network adapters: {ex.Message}");
            }
        }



        static void SetConsoleColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        static void ResetConsoleColor()
        {
            Console.ResetColor();
        }



        static void RemoveDriver(string driverName)
        {
            try
            {
                string driverPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers", driverName);
                if (File.Exists(driverPath))
                {
                    File.Delete(driverPath);
                    Console.WriteLine($"Driver {driverName} removed successfully.");
                }
                else
                {
                    Console.WriteLine($"Driver {driverName} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to remove driver {driverName}: {ex.Message}");
            }
        }

        static void DllRun(string dllName, string functionName)
        {
            try
            {
                // Den Pfad zur aktuellen EXE ermitteln
                string exeDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                // Der vollständige Pfad zur DLL im gleichen Verzeichnis wie die EXE
                string dllPath = Path.Combine(exeDirectory, dllName);

                // Prüfen, ob die DLL existiert
                if (!File.Exists(dllPath))
                {
                    Console.WriteLine("Die DLL wurde im aktuellen Verzeichnis nicht gefunden.");
                    return;
                }

                // Pfad zu rundll32.exe (System32 für 64-Bit, SysWow64 für 32-Bit-Anwendungen)
                string rundll32Path = @"C:\Windows\System32\rundll32.exe";

                // Argumente für rundll32.exe: DLL und Funktion
                string arguments = $"\"{dllPath}\", {functionName}";

                // Starten von rundll32.exe mit den entsprechenden Argumenten
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = rundll32Path,
                    Arguments = arguments,
                    UseShellExecute = false, // Verhindert, dass ein neues Fenster geöffnet wird
                    WorkingDirectory = exeDirectory // Setzt das Arbeitsverzeichnis auf das Verzeichnis der EXE
                };

                // Prozess starten und auf Beendigung warten
                using (Process process = Process.Start(startInfo))
                {
                    process.WaitForExit();
                    Console.WriteLine("DLL-Funktion wurde erfolgreich ausgeführt.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Ausführen der DLL-Funktion: " + ex.Message);
            }
        }

        static void RemoveDriverRegistryEntries(string driverKey)
        {
            try
            {
                string servicesPath = $@"SYSTEM\CurrentControlSet\Services\{driverKey}";
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(servicesPath, writable: true))
                {
                    if (key != null)
                    {
                        Registry.LocalMachine.DeleteSubKeyTree(servicesPath);
                        Console.WriteLine($"Registry entry for driver {driverKey} removed.");
                    }
                    else
                    {
                        Console.WriteLine($"Registry entry for driver {driverKey} not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to remove registry entry for driver {driverKey}: {ex.Message}");
            }
        }

        // Methode zum Neustarten des Systems
        static void RestartSystem()
        {
            try
            {
                Console.WriteLine("System will restart now...");

                // Neustart mit dem Systembefehl
                Process.Start(new ProcessStartInfo("shutdown", "/r /t 0")
                {
                    CreateNoWindow = true,
                    UseShellExecute = false
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to restart system: {ex.Message}");
            }
        }
    }
}





