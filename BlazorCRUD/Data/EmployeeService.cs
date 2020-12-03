using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.Data
{
    public class EmployeeService
    {
        private readonly ApplicationDbContext _db;

        public EmployeeService(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<EmployeeInfo> GetEmployee()
        {
            return _db.employees.ToList();
        }

        public EmployeeInfo GetEmployeeById(int id)
        {
            return _db.employees.Where(s=>s.EmployeeID == id).FirstOrDefault();
        }

        public bool CreateEmployee(EmployeeInfo employee)
        {
            _db.employees.Add(employee);
            _db.SaveChanges();
            return true;
        }

        public bool UpdateEmployee(EmployeeInfo employee)
        {
            _db.employees.Update(employee);
            _db.SaveChanges();
            return true;
        }

        public bool DeleteEmployee(EmployeeInfo employee)
        {
            _db.employees.Remove(employee);
            _db.SaveChanges();
            return true;
        }
    }
}
