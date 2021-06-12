using System;

namespace CollegeRecordApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CollegeRecord collegeRecord = new CollegeRecord();
            string userChoice= "Y";
            int selectedOption;

            Console.WriteLine("Thank you for using CollegeRecorc version 1.0");

            do
            {
                Console.WriteLine("\nPlease select an option:\n\n");
                Console.WriteLine("[1] Add new department\n" +
                                  "[2] Add new staff\n" +
                                  "[3] Remove staff by ID\n" +
                                  "[4] Remove staff by phone number\n" +
                                  "[5] Search staff by ID\n" +
                                  "[6] Search staff by phone number\n" +
                                  "[7] Display all staff from department\n" +
                                  "[8] Show all departments\n"
                );
                Console.WriteLine("\nPlease enter a number corresponding to an option:");

                selectedOption = Convert.ToInt16(Console.ReadLine());

                switch(selectedOption)
                {
                    case 1:
                        int departmentId = 0;
                        bool isDepartmentIdFree = false;
                        bool isStaffIdCorrectType = false;
                        do
                        {
                            do
                            {
                                Console.WriteLine("Enter department ID:");

                                try
                                {
                                    departmentId = Convert.ToInt32(Console.ReadLine());
                                    isStaffIdCorrectType = true;
                                }
                                catch (FormatException fe)
                                {
                                    Console.WriteLine($"Incorrect ID format entered. The ID should include only digits. You entered: {departmentId}");
                                    Console.WriteLine(fe.Message);
                                }

                            } while (!isStaffIdCorrectType);

                            if (collegeRecord.isDepartmentIdTaken(departmentId))
                            {
                                Console.WriteLine($"The ID {departmentId} is already being used by another department");
                            }
                            else 
                            {
                                isDepartmentIdFree = true;
                            }

                        } while (!isDepartmentIdFree);

                        Console.WriteLine("Enter department name:");
                        String departmentName = Convert.ToString(Console.ReadLine());
                        collegeRecord.addDepartment(departmentId, departmentName);
                        break;
                    case 2:
                        int staffType;

                        do
                        {
                            Console.WriteLine("Please select the type of staff you want to add - [1] academic [2] administrative");
                            staffType = Convert.ToInt16(Console.ReadLine());

                        } while (! (staffType == 1 || staffType == 2));

                        int staffId;
                        bool isStaffIdFree = false;
                        string academicTitle = "";
                        string firstName;
                        string lastName;
                        string phoneNumber;
                        string email;
                        string jobTitle;
                        string staffDepartment;
                        bool isFullTimeStaff;
                        bool hasTeachingExperience = false;

                        do
                        {
                            Console.WriteLine("Enter staff ID:");
                            staffId = Convert.ToInt32(Console.ReadLine());

                            if (collegeRecord.isStaffIdTaken(staffId))
                            {
                                Console.WriteLine($"The ID {staffId} is already being used by existing staff");
                            }
                            else 
                            {
                                isStaffIdFree = true;
                            }

                        } while (!isStaffIdFree);


                        if (staffType == 1) 
                        {
                            Console.WriteLine("Please enter the title of the staff (Dr, Professor, etc.)");
                            academicTitle = Convert.ToString(Console.ReadLine());
                        }

                        Console.WriteLine("Enter the staff's first name: ");
                        firstName = Convert.ToString(Console.ReadLine());

                        Console.WriteLine("Enter the staff's last name: ");
                        lastName = Convert.ToString(Console.ReadLine());

                        Console.WriteLine("Enter the staff's phone number: ");
                        phoneNumber = Convert.ToString(Console.ReadLine());

                        Console.WriteLine("Enter the staff's email address: ");
                        email = Convert.ToString(Console.ReadLine());

                        Console.WriteLine("Enter the staff's job title: ");
                        jobTitle = Convert.ToString(Console.ReadLine());

                        bool isValidDepartment = false;

                        do
                        {
                            Console.WriteLine("Enter the staff's department: ");
                            staffDepartment = Convert.ToString(Console.ReadLine());

                            if (collegeRecord.getDepartmentByName(staffDepartment) == null)
                            {
                                Console.WriteLine("[ERROR] Invalid department name entered");
                                Console.WriteLine("List of existing departments: ");
                                collegeRecord.printDepartmentList();
                            }
                            else
                            {
                                isValidDepartment = true;
                            }

                        } while (!isValidDepartment); 
                

                        string staffFullTimeEmploymentSelection;

                        do
                        {
                            Console.WriteLine("Is the staff employed full-time: (Y/N)");
                            staffFullTimeEmploymentSelection = Convert.ToString(Console.ReadLine());

                        } while (! (staffFullTimeEmploymentSelection.ToLower().Equals("y") || staffFullTimeEmploymentSelection.ToLower().Equals("n")));

                        isFullTimeStaff = staffFullTimeEmploymentSelection.ToLower().Equals("y") ? true : false;


                        string staffTeachingExperienceSelection;

                        if (staffType == 2) 
                        {
                            do
                            {
                                Console.WriteLine("Does this administrative staff have any teaching experience: (Y/N)");
                                staffTeachingExperienceSelection = Convert.ToString(Console.ReadLine());

                            } while (! (staffTeachingExperienceSelection.ToLower().Equals("y") || staffTeachingExperienceSelection.ToLower().Equals("n")));

                            hasTeachingExperience = staffTeachingExperienceSelection.ToLower().Equals("y") ? true : false;
                        }

                        Staff newStaff;

                        if (staffType == 1) 
                        {
                            newStaff = new AcademicStaff(staffId, academicTitle, firstName, lastName, phoneNumber, email, jobTitle, staffDepartment, isFullTimeStaff);
                        }
                        else
                        {
                            newStaff = new AdministrativeStaff(staffId, firstName, lastName, phoneNumber, email, jobTitle, staffDepartment, isFullTimeStaff, hasTeachingExperience);
                        }

                        collegeRecord.addStaff(newStaff);
                        break;
                    case 3:
                        Console.WriteLine("Please enter the ID of the staff you want to remove: ");
                        int idOfStaffToBeRemoved = 0;
                        isStaffIdCorrectType = false;

                        do
                        {
                            Console.WriteLine("Please enter staff ID: ");

                            try
                            {
                                idOfStaffToBeRemoved = Convert.ToInt32(Console.ReadLine());
                                isStaffIdCorrectType = true;
                            }
                            catch (FormatException fe)
                            {
                                Console.WriteLine($"Incorrect ID format entered. The ID should include only digits. You entered: {idOfStaffToBeRemoved}");
                            }

                        } while (!isStaffIdCorrectType);

                        if (!collegeRecord.isStaffIdTaken(idOfStaffToBeRemoved)) 
                        {
                            Console.WriteLine("[ERROR] Non-existing ID: " + idOfStaffToBeRemoved);
                        }
                        else
                        {
                            collegeRecord.removeStaffById(idOfStaffToBeRemoved);
                        }
                        break;
                    case 4:
                        Console.WriteLine("Please enter the phone number of the staff you want to remove: ");
                        string phoneNumberOfStaffToBeRemoved = Convert.ToString(Console.ReadLine());

                        Staff removedStaff = collegeRecord.removeStaffByPhoneNumber(phoneNumberOfStaffToBeRemoved);

                        if (removedStaff == null) 
                        {
                            Console.WriteLine($"No staff with phone number {phoneNumberOfStaffToBeRemoved} was found in the record");
                        }
                        break;
                    case 5:
                        int idOfStaffToBeSearched = 0;
                        isStaffIdCorrectType = false;

                        do
                        {
                            Console.WriteLine("Please enter staff ID: ");

                            try
                            {
                                idOfStaffToBeSearched = Convert.ToInt32(Console.ReadLine());
                                isStaffIdCorrectType = true;
                            }
                            catch (FormatException fe)
                            {
                                Console.WriteLine($"Incorrect ID format entered. The ID should include only digits. You entered: {idOfStaffToBeSearched}");
                            }

                        } while (!isStaffIdCorrectType);

                        Staff staffResultById = collegeRecord.getStaffById(idOfStaffToBeSearched);

                        if (staffResultById == null) 
                        {
                            Console.WriteLine($"No staff with ID {idOfStaffToBeSearched} was found");
                        }

                        break;
                    case 6:
                        Console.WriteLine("Please enter staff phone number: ");
                        string phoneNumberOfStaffToBeSearched = Convert.ToString(Console.ReadLine());

                        Staff staffResultByPhoneNumber = collegeRecord.getStaffByPhoneNumber(phoneNumberOfStaffToBeSearched);

                        if (staffResultByPhoneNumber == null)
                        {
                            Console.WriteLine($"No staff with phone number {phoneNumberOfStaffToBeSearched} was found");
                        }
 
                        break;
                    case 7:
                        Console.WriteLine("Please enter department name: ");
                        string departmentNameSearched = Convert.ToString(Console.ReadLine());

                        if (collegeRecord.getDepartmentByName(departmentNameSearched) == null)
                        {
                            Console.WriteLine($"No department with name {departmentNameSearched} was found");
                        }
                        else
                        {
                            collegeRecord.getDepartmentStaff(departmentNameSearched);
                        }
                        break;
                    case 8:
                        collegeRecord.printDepartmentList();
                        break;
                    default:
                        Console.WriteLine("Invalid option selected, please try again");
                        break;
                }


                Console.WriteLine("\nDo you wish to continue (Y/N) :");
                userChoice = Convert.ToString(Console.ReadLine());

            } while (userChoice.ToLower().Equals("y"));
        }
    }
}
