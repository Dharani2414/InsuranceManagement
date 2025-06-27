using DAO;
using Microsoft.EntityFrameworkCore;
using System;
using Entity;
using System.Collections.Generic;

namespace InsuranceManagement
{
    public class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<InsuranceDBContext>()
                .UseSqlServer("Server=LAPTOP-L4FV7ODF\\SQLEXPRESS01;Database=InsuranceDb;Trusted_Connection=True;Encrypt=false")
                .Options;

            var context = new InsuranceDBContext(options);
            IPolicyService policyService = new IPolicyServiceImpl(context);
            UserService userRepo = new UserServiceImpl();

            while (true)
            {
                Console.WriteLine("\n===== MAIN MENU =====");
                Console.WriteLine("1. User Operations");
                Console.WriteLine("2. Policy Operations");
                Console.WriteLine("3. Exit");
                Console.Write("Enter choice: ");
                string mainChoice = Console.ReadLine();

                switch (mainChoice)
                {
                    case "1":
                        ShowUserMenu(userRepo);
                        break;
                    case "2":
                        ShowPolicyMenu(policyService);
                        break;
                    case "3":
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine(" Invalid choice.");
                        break;
                }
            }
        }

        static void ShowUserMenu(UserService userRepo)
        {
            while (true)
            {
                Console.WriteLine("\n===== USER MENU =====");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. View All Users");
                Console.WriteLine("3. Login");
                Console.WriteLine("4. Delete User");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var user = new User();
                        Console.Write("Enter Username: ");
                        user.Username = Console.ReadLine();
                        Console.Write("Enter Password: ");
                        user.Password = Console.ReadLine();
                        Console.Write("Enter Role: ");
                        user.Role = Console.ReadLine();

                        bool added = userRepo.AddUser(user);
                        Console.WriteLine(added ? " User added." : " Failed to add user.");
                        break;

                    case "2":
                        var users = userRepo.GetAllUsers();
                        Console.WriteLine($"\n{"ID",-5} {"Username",-15} {"Role",-10}");
                        Console.WriteLine("-----------------------------------------");
                        foreach (var u in users)
                            Console.WriteLine($"{u.UserId,-5} {u.Username,-15} {u.Role,-10}");
                        break;

                    case "3":
                        Console.Write("Enter Username: ");
                        string uname = Console.ReadLine();
                        Console.Write("Enter Password: ");
                        string pwd = Console.ReadLine();

                        bool loggedIn = userRepo.Login(uname, pwd);
                        Console.WriteLine(loggedIn ? " Login successful." : " Invalid credentials.");
                        break;

                    case "4":
                        Console.Write("Enter User ID to delete: ");
                        int id = int.Parse(Console.ReadLine());
                        bool deleted = userRepo.DeleteUser(id);
                        Console.WriteLine(deleted ? " User deleted." : " User not found.");
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine(" Invalid choice.");
                        break;
                }
            }
        }

        static void ShowPolicyMenu(IPolicyService service)
        {
            while (true)
            {
                Console.WriteLine("\n===== POLICY MENU =====");
                Console.WriteLine("1. Add Policy");
                Console.WriteLine("2. View All Policies");
                Console.WriteLine("3. Get Policy by ID");
                Console.WriteLine("4. Update Policy");
                Console.WriteLine("5. Delete Policy");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var newPolicy = new Policy();
                        Console.Write("Enter Policy Name: ");
                        newPolicy.PolicyName = Console.ReadLine();
                        Console.Write("Enter Policy Type: ");
                        newPolicy.PolicyType = Console.ReadLine();
                        Console.Write("Enter Coverage Amount: ");
                        newPolicy.CoverageAmount = decimal.Parse(Console.ReadLine());

                        bool added = service.AddPolicy(newPolicy);
                        Console.WriteLine(added ? " Policy added." : " Failed to add policy.");
                        break;

                    case "2":
                        var allPolicies = service.GetAllPolicies();
                        if (allPolicies.Count == 0)
                        {
                            Console.WriteLine("No policies found.");
                        }
                        else
                        {
                            Console.WriteLine("--------------------------------------------------------------------------------------------------");
                            Console.WriteLine($"{"Policy ID",-10} {"Policy Name",-30} {"Policy Type",-20} {"Coverage Amount",15}");
                            Console.WriteLine("--------------------------------------------------------------------------------------------------");

                            foreach (var p in allPolicies)
                                Console.WriteLine($"{p.PolicyId,-10} {p.PolicyName,-30} {p.PolicyType,-20} {p.CoverageAmount,15}");

                            Console.WriteLine("--------------------------------------------------------------------------------------------------");
                        }
                        break;

                    case "3":
                        Console.Write("Enter Policy ID: ");
                        int id = int.Parse(Console.ReadLine());
                        var policy = service.GetPolicyById(id);
                        if (policy != null)
                            Console.WriteLine($"ID: {policy.PolicyId}, Name: {policy.PolicyName}, Type: {policy.PolicyType}, Amount: {policy.CoverageAmount}");
                        else
                            Console.WriteLine(" Policy not found.");
                        break;

                    case "4":
                        Console.Write("Enter Policy ID to update: ");
                        int updateId = int.Parse(Console.ReadLine());
                        var existingPolicy = service.GetPolicyById(updateId);
                        if (existingPolicy == null)
                        {
                            Console.WriteLine(" Policy not found.");
                            break;
                        }

                        Console.Write("Enter new Policy Name: ");
                        existingPolicy.PolicyName = Console.ReadLine();
                        Console.Write("Enter new Policy Type: ");
                        existingPolicy.PolicyType = Console.ReadLine();
                        Console.Write("Enter new Coverage Amount: ");
                        existingPolicy.CoverageAmount = decimal.Parse(Console.ReadLine());

                        bool updated = service.UpdatePolicy(existingPolicy);
                        Console.WriteLine(updated ? " Policy updated." : " Update failed.");
                        break;

                    case "5":
                        Console.Write("Enter Policy ID to delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        bool deleted = service.DeletePolicy(deleteId);
                        Console.WriteLine(deleted ? " Policy deleted." : " Policy not found.");
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine(" Invalid choice.");
                        break;
                }
            }
        }
    }
}
