using System;
using System.Collections.Generic;


public class CollegeRecord
{
    private LinkedList<Staff> staffs;
    private List<Department> departments; //Normal list since the number of departments would not change often

    public CollegeRecord()
    {
        this.staffs = new LinkedList<Staff>();
        this.departments = new List<Department>();
    }

    public CollegeRecord(LinkedList<Staff> staffs, List<Department> departments) 
    {
        this.staffs = staffs;
        this.departments = departments;
    }

    public void addDepartment(int id, string departmentName)
    {
       Department department = new Department(id, departmentName);
       this.departments.Add(department);

        Console.WriteLine("\nNew department successfully added");
    }

    
    public void addStaff(Staff staff)
    {
       string staffType = staff.GetType() == typeof(AcademicStaff) ? "academic" : "administrative";

       this.staffs.AddLast(staff);
        Console.WriteLine("New " + staffType + " staff successfully added");

    }

    /* Remove staff with specified ID and return it, if existing */
    public Staff removeStaffById(int id)
    {
        Staff staffToRemove = null;

        foreach (Staff staff in this.staffs) 
        { 
            if (staff.Id == id) 
            {
                Console.WriteLine($"Removing staff with id: {id}\n{staff}");
                staffToRemove = staff;
            }
        }

        this.staffs.Remove(staffToRemove);

        return staffToRemove;
    }

    /* Remove staff with specified phone number and return it, if existing */
    public Staff removeStaffByPhoneNumber(string phoneNumber) 
    {
        Staff staffToRemove = null;

        foreach (Staff staff in this.staffs)
        {
            if (staff.PhoneNumber.Equals(phoneNumber))
            {
                Console.WriteLine($"Removing staff with phone number: {phoneNumber}\n {staff}");
                staffToRemove = staff;
            }
        }

        this.staffs.Remove(staffToRemove);

        return staffToRemove;
    }

    public int getNumDepartments()
    {
        return this.departments.Count;
    }

    public int getNumStaff()
    {
        return this.staffs.Count;
    }

    /* Log all staff that works in a given department */
    public void getDepartmentStaff(string departmentName)
    {
        if (this.staffs.Count == 0)
        {
            Console.WriteLine("There are currently no staff records in the system");
        }

        foreach (Staff staff in this.staffs)
        {
            if (staff.Department.Equals(departmentName))
            {
                Console.WriteLine($"ID: {staff.Id}, First Name: {staff.FirstName}, Last Name: {staff.LastName}, Job Title: {staff.JobTitle}");
            }
        }
    }

    public Department getDepartmentByName(string departmentName)
    {
        foreach (Department department in this.departments)
        {
            if (department.DepartmentName.Equals(departmentName))
            {
                return department;
            }
        }

        return null;
    }
    public void printDepartmentList()
    {
        if (this.departments.Count == 0) 
        {
            Console.WriteLine("There are currently no departments in the system");
        }

        foreach (Department department in this.departments)
        {
            Console.WriteLine(department.ToString());
        }
    }

    public Staff getStaffById(int id)
    {
        foreach (Staff staff in this.staffs)
        {
            if (staff.Id == id)
            {
                Console.WriteLine($"Retrieving staff with id: {id} \n{staff}");
                return staff;
            }
        }

        return null;
    }

    public Staff getStaffByPhoneNumber(string phoneNumber)
    {
        foreach (Staff staff in this.staffs)
        {
            if (staff.PhoneNumber == phoneNumber)
            {
                Console.WriteLine($"Retrieving staff with phone number: {staff.PhoneNumber}\n {staff}");
                return staff;
            }
        }

        return null;
    }

    public bool isDepartmentIdTaken(int departmentId) 
    { 
        foreach (Department department in this.departments)
        {
            if (department.Id == departmentId) 
            {
                return true;
            }
        }

        return false;
    }


    public bool isStaffIdTaken(int staffId)
    {
        foreach (Staff staff in this.staffs)
        {
            if (staff.Id == staffId)
            {
                return true;
            }
        }

        return false;
    }
}
