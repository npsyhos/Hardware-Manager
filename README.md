# Hardware-Manager
A lightweight application to manage your hardware.

HardwareServices is a DLL that makes queries to Windows Management Instrumentation in order to get hardware information. 

HardwareGUI utilizes HardwareServices in order to obtain the necessary information to populate the TreeView. It's GUI is similar in 
structure and use to Windows Device Manager. 

My original plan was to also include the current temperatures of relevant pieces of hardware, similar to Open Hardware Monitor. After some 
research, I found that the only realistic way to implement that would be to use the Open Hardware Monitors library which wouldn't be as 
great of a learning experience.

I hope you enjoy, and feel free to message me with any questions or suggestions! :)
