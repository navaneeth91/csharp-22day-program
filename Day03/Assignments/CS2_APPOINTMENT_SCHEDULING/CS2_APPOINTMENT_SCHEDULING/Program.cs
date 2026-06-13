using System;
using System.Collections.Generic;

class Appointment
{
    public string PatientName;
    public string Department;
    public string Doctor;
    public string Time;
}

class Program
{
    static void Main()
    {
        string[] departments = { "General Medicine", "Dental", "Orthopedics" };

        List<string> generalDoctors = new List<string>()
        {
            "Dr. A. Kumar",
            "Dr. B. Singh"
        };

        List<string> dentalDoctors = new List<string>()
        {
            "Dr. C. Roy",
            "Dr. D. Gupta"
        };

        List<string> orthoDoctors = new List<string>()
        {
            "Dr. E. Sharma",
            "Dr. F. Patel"
        };

        string[] slots = { "10:00 AM", "11:00 AM", "12:00 PM" };

        Console.WriteLine("-------------------------------------");
        Console.WriteLine("APPOINTMENT BOOKING SYSTEM");
        Console.WriteLine("-------------------------------------");

        Console.Write("Enter Patient Name: ");
        string patientName = Console.ReadLine();

        int deptChoice = 0;

        // Department selection
        while (true)
        {
            Console.WriteLine("\nSelect Department");

            for (int i = 0; i < departments.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + departments[i]);
            }

            Console.Write("Enter Choice: ");

            if (int.TryParse(Console.ReadLine(), out deptChoice))
            {
                if (deptChoice >= 1 && deptChoice <= 3)
                {
                    break;
                }
            }

            Console.WriteLine("Invalid choice. Try again.");
        }

        List<string> doctors = new List<string>();

        if (deptChoice == 1)
        {
            doctors = generalDoctors;
        }
        else if (deptChoice == 2)
        {
            doctors = dentalDoctors;
        }
        else
        {
            doctors = orthoDoctors;
        }

        int doctorChoice = 0;

        // Doctor selection
        while (true)
        {
            Console.WriteLine("\nSelect Doctor");

            for (int i = 0; i < doctors.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + doctors[i]);
            }

            Console.Write("Enter Choice: ");

            if (int.TryParse(Console.ReadLine(), out doctorChoice))
            {
                if (doctorChoice >= 1 && doctorChoice <= doctors.Count)
                {
                    break;
                }
            }

            Console.WriteLine("Invalid choice. Try again.");
        }

        int slotChoice = 0;

        // Time slot selection
        while (true)
        {
            Console.WriteLine("\nSelect Time Slot");

            for (int i = 0; i < slots.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + slots[i]);
            }

            Console.Write("Enter Choice: ");

            if (int.TryParse(Console.ReadLine(), out slotChoice))
            {
                if (slotChoice >= 1 && slotChoice <= slots.Length)
                {
                    break;
                }
            }

            Console.WriteLine("Invalid choice. Try again.");
        }

        Appointment appt = new Appointment();

        appt.PatientName = patientName;
        appt.Department = departments[deptChoice - 1];
        appt.Doctor = doctors[doctorChoice - 1];
        appt.Time = slots[slotChoice - 1];

        Console.WriteLine("\nBooking Confirmed!");

        Console.WriteLine("\n-------------------------------------");
        Console.WriteLine("APPOINTMENT TICKET");
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("Patient Name : " + appt.PatientName);
        Console.WriteLine("Department   : " + appt.Department);
        Console.WriteLine("Doctor       : " + appt.Doctor);
        Console.WriteLine("Time Slot    : " + appt.Time);
        Console.WriteLine("Status       : Confirmed");
        Console.WriteLine("-------------------------------------");
    }
}