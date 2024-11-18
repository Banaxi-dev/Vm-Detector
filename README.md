

# VM Checker

This tool is designed to help detect whether the system is running inside a virtual machine (VM) or on physical hardware. It performs a series of checks across different system areas, including BIOS information, MAC addresses, registry keys, processes, hardware details, and more.

## Features

- **BIOS Information Check**: Determines if the BIOS hints at a virtual machine environment.
- **MAC Address Check**: Checks multiple network interfaces for MAC addresses typically associated with virtual machines.
- **Registry Key Check**: Examines the system registry for keys related to VMware and VirtualBox tools.
- **User Directory Check**: Analyzes the user profile path for potential VM-related folders.
- **Process and Service Check**: Looks for processes and services commonly found in virtual machines.
- **CPU Information Check**: Assesses the CPU model and makes sure it’s typical of a physical machine.
- **Disk Information Check**: Inspects the disk model to look for virtual disk signatures.
- **Mouse Movement Check**: Monitors mouse movement patterns to detect virtual environments.
- **GPU Check**: Tries to access GPU 3D performance data to detect virtualized GPUs.
- **RAM Size and CPU Core Count Check**: Verifies that system specs align with typical physical hardware configurations.
- **Host Name Check**: Assesses the system hostname for VM indicators.
- **Nested Virtualization Check**: Looks for signs that nested virtualization is enabled, suggesting a virtualized environment.
- **System Boot Time Check**: Verifies system uptime to detect rapid VM boot times.
- **Hardware Manufacturer Check**: Matches system manufacturer to common VM environments.
- **Network Adapter Check**: Scans for virtual network adapters, often present in VMs.
- **WMI Errors Check**: Looks for any issues with WMI that might indicate a VM environment.

## How to Use

1. Go on Releases
2. Download the Exe file.
3. Run the `VMChecker.exe` file.
5. Based on the results, the tool will inform you if a virtual machine is detected, and if so, provide insights into which components suggested this detection.

## Usage

1. Run the program and choose one of the following options:
    - **D**: Detect the current PC configuration.
    - **T**: Attempt to remove VM traces (use with caution).

2. The program will perform a series of checks and display the results in the console.

3. Review the results to determine if the system is running in a virtualized environment.

### Example Output:

```python
[2024-11-18 15:31:06] Console cleared.

Checking BIOS Information...
BIOS Manufacturer: LENOVO
BIOS Version: LENOVO - 1
BIOS Serial Number: PF3749WC
No VM detected based on BIOS information.

Checking MAC Addresses...
No VM detected based on MAC address.
No VM detected based on MAC address.
VM detected based on MAC address.

Checking Registry Keys...
No VM detected based on registry key: HKEY_LOCAL_MACHINE\SOFTWARE\VMware, Inc.\VMware Tools

Checking CPU Information...
CPU: Intel(R) Core(TM) i5-10210U CPU @ 1.60GHz
No VM detected based on CPU information.

Checking GPU 3D performance...
Error checking GPU 3D performance: Nicht gefunden
No 3D GPU detected. Likely a VM environment.

Checking RAM Size...
Total RAM: 8025 MB
RAM size is normal.

Detection completed.
```

### Options:
- **R**: Clear the console and re-run the checks.
- **E**: Exit the detection process.

## Requirements

- Windows Operating System (Tested on Windows 10 and Windows 11).
- No additional dependencies are required to run the tool.

## Contributing

Feel free to fork this repository, create pull requests, and contribute by adding more checks or improving existing ones.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.



## Disclaimer

- **Option T (Remove VM traces)**: This option can be dangerous and may cause system instability. Use it at your own risk. The author is not responsible for any damages that may occur.
