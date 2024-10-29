using System;
using System.Collections.Generic;

public class ClubRole
{
    private string name;
    private string role;
    private string contactInfo;

    public ClubRole(string name, string role, string contactInfo)
    {
        this.name = name;
        this.role = role;
        this.contactInfo = contactInfo;
    }

    public string GetName() { return name; }
    public string GetRole() { return role; }
    public string GetContactInfo() { return contactInfo; }
}

public class Activity
{
    public string Name { get; set; }

    public Activity(string name)
    {
        Name = name;
    }
}

public class Society
{
    private string name;
    private string contact;
    private List<Activity> activities;

    public Society(string name, string contact)
    {
        this.name = name;
        this.contact = contact;
        this.activities = new List<Activity>();
    }

    public void AddActivity(Activity activity)
    {
        activities.Add(activity);
    }

    public List<Activity> ListEvents()
    {
        return activities;
    }

    public string GetName() { return name; }
    public string GetContact() { return contact; }
}

public class FundedSociety : Society
{
    private double fundingAmount;

    public FundedSociety(string name, string contact, double fundingAmount)
        : base(name, contact)
    {
        this.fundingAmount = fundingAmount;
    }

    public double GetFundingAmount() { return fundingAmount; }
}

public class NonFundedSociety : Society
{
    public NonFundedSociety(string name, string contact)
        : base(name, contact)
    {
    }
}

public class StudentClub
{
    private double budget;
    private ClubRole president;
    private ClubRole vicePresident;
    private ClubRole generalSecretary;
    private ClubRole financeSecretary;
    private List<Society> societies;

    public StudentClub(double budget, ClubRole president, ClubRole vicePresident, ClubRole generalSecretary, ClubRole financeSecretary)
    {
        this.budget = budget;
        this.president = president;
        this.vicePresident = vicePresident;
        this.generalSecretary = generalSecretary;
        this.financeSecretary = financeSecretary;
        this.societies = new List<Society>();
    }

    public void FundSociety(Society society)
    {
        societies.Add(society);
    }

    public void DispenseFunds()
    {
        foreach (var society in societies)
        {
            if (society is FundedSociety fundedSociety)
            {
                budget -= fundedSociety.GetFundingAmount();
            }
        }
    }

    public void RegisterSociety(Society society)
    {
        societies.Add(society);
    }

    public void DisplaySocieties()
    {
        foreach (var society in societies)
        {
            if (society is FundedSociety fundedSociety)
            {
                Console.WriteLine($"Society: {fundedSociety.GetName()}, Contact: {fundedSociety.GetContact()}, Funding: ${fundedSociety.GetFundingAmount()}");
            }
            else
            {
                Console.WriteLine($"Society: {society.GetName()}, Contact: {society.GetContact()}, Funding: $0");
            }
        }
    }

    public void DisplayEvents()
    {
        foreach (var society in societies)
        {
            Console.WriteLine($"Society: {society.GetName()}");
            Console.WriteLine("Events:");
            foreach (var activity in society.ListEvents())
            {
                Console.WriteLine($" - {activity.Name}");
            }
        }
    }

    public void DisplayClubRoles()
    {
        Console.WriteLine("Club Roles:");
        Console.WriteLine($"President: {president.GetName()}, Contact: {president.GetContactInfo()}");
        Console.WriteLine($"Vice President: {vicePresident.GetName()}, Contact: {vicePresident.GetContactInfo()}");
        Console.WriteLine($"General Secretary: {generalSecretary.GetName()}, Contact: {generalSecretary.GetContactInfo()}");
        Console.WriteLine($"Finance Secretary: {financeSecretary.GetName()}, Contact: {financeSecretary.GetContactInfo()}");
    }

    public List<Society> GetSocieties()
    {
        return societies;
    }
}

class Program
{
    static void Main()
    {
        ClubRole president = new ClubRole("Ali", "President", "ali@gmail.com");
        ClubRole vicePresident = new ClubRole("Ahsan", "Vice President", "ahsanali@gmail.com");
        ClubRole generalSecretary = new ClubRole("Alia", "General Secretary", "alia@example.com");
        ClubRole financeSecretary = new ClubRole("Hassan", "Finance Secretary", "hassanali@gmail.com");

        StudentClub studentClub = new StudentClub(5000, president, vicePresident, generalSecretary, financeSecretary);

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Register New Society");
            Console.WriteLine("2. Allocate Funding to Society");
            Console.WriteLine("3. Register Event for Society");
            Console.WriteLine("4. Display Society Funding Information");
            Console.WriteLine("5. Display Events for Society");
            Console.WriteLine("6. Display Club Roles");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    RegisterNewSociety(studentClub);
                    break;
                case 2:
                    AllocateFunding(studentClub);
                    break;
                case 3:
                    RegisterEvent(studentClub);
                    break;
                case 4:
                    studentClub.DisplaySocieties();
                    break;
                case 5:
                    studentClub.DisplayEvents();
                    break;
                case 6:
                    studentClub.DisplayClubRoles();
                    break;
                case 7:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void RegisterNewSociety(StudentClub studentClub)
    {
        Console.Write("Enter society name: ");
        string name = Console.ReadLine();
        Console.Write("Enter contact name: ");
        string contact = Console.ReadLine();
        Console.Write("Is this a funded society? (yes/no): ");
        string funded = Console.ReadLine().ToLower();

        if (funded == "yes")
        {
            Console.Write("Enter funding amount: ");
            double fundingAmount = Convert.ToDouble(Console.ReadLine());
            studentClub.RegisterSociety(new FundedSociety(name, contact, fundingAmount));
        }
        else
        {
            studentClub.RegisterSociety(new NonFundedSociety(name, contact));
        }

        Console.WriteLine("Society registered successfully!");
    }

    static void AllocateFunding(StudentClub studentClub)
    {
        studentClub.DispenseFunds();
        Console.WriteLine("Funds dispensed successfully!");
    }

    static void RegisterEvent(StudentClub studentClub)
    {
        Console.Write("Enter society name: ");
        string name = Console.ReadLine();
        Society society = null;
        foreach (var soc in studentClub.GetSocieties())
        {
            if (soc.GetName() == name)
            {
                society = soc;
                break;
            }
        }

        if (society != null)
        {
            Console.Write("Enter event name: ");
            string eventName = Console.ReadLine();
            society.AddActivity(new Activity(eventName));
            Console.WriteLine("Event registered successfully!");
        }
        else
        {
            Console.WriteLine("Society not found.");
        }
    }
}
