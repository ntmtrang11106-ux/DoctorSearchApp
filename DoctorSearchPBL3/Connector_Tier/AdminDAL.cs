using DTO_Tier;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL_Tier
{
    public class AdminDAL
    {
        private readonly AppDbContext _context = new AppDbContext();

        public List<UserDTO> GetAllUsers()
        {
            using var db = new AppDbContext();
            return db.Users
                .Where(u => !u.IsDeleted)
                .OrderByDescending(u => u.CreatedAt)
                .ToList();
        }

        public List<DoctorDTO> GetPendingDoctors()
        {
            using var db = new AppDbContext();
            return db.Doctors
                .Include(d => d.User)
                .Include(d => d.Department)
                .Include(d => d.Certificates)
                .Where(d => !d.IsApproved && !d.IsDeleted)
                .OrderByDescending(d => d.CreatedAt)
                .ToList();
        }

        public bool ApproveDoctor(int doctorId)
        {
            using var db = new AppDbContext();
            var doctor = db.Doctors.Include(d => d.User).FirstOrDefault(d => d.Id == doctorId);
            if (doctor == null) return false;

            doctor.IsApproved = true;
            doctor.IsActive = true;
            doctor.UpdatedAt = DateTime.Now;

            // Also update the User status if needed
            if (doctor.User != null)
            {
                doctor.User.Status = "Active";
            }

            return db.SaveChanges() > 0;
        }

        public bool RejectDoctor(int doctorId)
        {
            using var db = new AppDbContext();
            var doctor = db.Doctors.Find(doctorId);
            if (doctor == null) return false;

            // Option 1: Soft delete
            doctor.IsDeleted = true;
            doctor.DeletedAt = DateTime.Now;

            // Also mark the associated User as deleted if they only have this role
            var user = db.Users.Find(doctor.UserId);
            if (user != null)
            {
                user.IsDeleted = true;
                user.DeletedAt = DateTime.Now;
            }

            return db.SaveChanges() > 0;
        }

        public bool UpdateUserStatus(int userId, string status)
        {
            using var db = new AppDbContext();
            var user = db.Users.Find(userId);
            if (user == null) return false;

            user.Status = status;
            user.UpdatedAt = DateTime.Now;

            return db.SaveChanges() > 0;
        }

        public List<UserDTO> SearchUsers(string keyword, string role)
        {
            using var db = new AppDbContext();
            var query = db.Users.Where(u => !u.IsDeleted).AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(u => u.FullName.Contains(keyword) || u.PhoneNumber.Contains(keyword));
            }

            if (!string.IsNullOrWhiteSpace(role) && role != "Tất cả")
            {
                query = query.Where(u => u.Role == role);
            }
            else
            {
                // If "All" is selected, only show Doctors and Patients
                query = query.Where(u => u.Role != "Admin");
            }

            return query.OrderByDescending(u => u.CreatedAt).ToList();
        }

        public (UserDTO, DoctorDTO, PatientDTO) GetFullUserDetails(int userId, string role)
        {
            using var db = new AppDbContext();
            var user = db.Users.Find(userId);
            if (user == null) return (null, null, null);

            DoctorDTO doc = null;
            PatientDTO pat = null;

            if (role == "Doctor")
            {
                doc = db.Doctors
                    .Include(d => d.Department)
                    .Include(d => d.Certificates)
                    .FirstOrDefault(d => d.UserId == userId);
            }
            else if (role == "Patient")
            {
                pat = db.Patients.FirstOrDefault(p => p.UserId == userId);
            }

            return (user, doc, pat);
        }

        public DoctorDTO GetDoctorByUserId(int userId)
        {
            using var db = new AppDbContext();
            return db.Doctors
                .Include(d => d.Department)
                .Include(d => d.User)
                .FirstOrDefault(d => d.UserId == userId);
        }

        public bool DeleteUser(int userId)
        {
            using var db = new AppDbContext();
            var user = db.Users.Find(userId);
            if (user == null) return false;

            user.IsDeleted = true;
            user.DeletedAt = DateTime.Now;

            // If it's a doctor, also mark doctor as deleted
            var doctor = db.Doctors.FirstOrDefault(d => d.UserId == userId);
            if (doctor != null)
            {
                doctor.IsDeleted = true;
                doctor.DeletedAt = DateTime.Now;
            }

            // If it's a patient, also mark patient as deleted
            var patient = db.Patients.FirstOrDefault(p => p.UserId == userId);
            if (patient != null)
            {
                patient.IsDeleted = true;
                patient.DeletedAt = DateTime.Now;
            }

            return db.SaveChanges() > 0;
        }
        public PatientDTO GetPatientByUserId(int userId)
        {
            using var db = new AppDbContext();
            var patient = db.Patients.FirstOrDefault(p => p.UserId == userId && !p.IsDeleted);
            if (patient == null) return null;

            return new PatientDTO
            {
                Id = patient.Id,
                UserId = patient.UserId,
                MedicalCode = patient.MedicalCode,
                InsuranceCode = patient.InsuranceCode,
                EmergencyContactName = patient.EmergencyContactName,
                EmergencyContactPhone = patient.EmergencyContactPhone,
                Note = patient.Note,
                CreatedAt = patient.CreatedAt
            };
        }
    }
}
