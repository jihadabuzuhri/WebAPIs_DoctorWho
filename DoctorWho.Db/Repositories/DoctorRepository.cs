using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DoctorWhoCoreDbContext _context;

        public DoctorRepository(DoctorWhoCoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Doctor>> GetAllDoctorsAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task AddDoctorAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDoctorAsync(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteDoctorAsync(int doctorId)
        {
            var doctor = await _context.Doctors.FindAsync(doctorId);
            
            if (doctor == null)
            {
                return false;
            }

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Doctor> UpsertDoctorAsync(int doctorId ,Doctor doctor)
        {
            var existingDoctor = await _context.Doctors.FindAsync(doctorId);

            if (existingDoctor == null)
            {
                await _context.Doctors.AddAsync(doctor);
            }
            else
            {
                doctor.DoctorId = doctorId;

                existingDoctor.DoctorName = doctor.DoctorName;
                existingDoctor.DoctorNumber = doctor.DoctorNumber;
                existingDoctor.BirthDate = doctor.BirthDate;
                existingDoctor.FirstEpisodeDate = doctor.FirstEpisodeDate;
                existingDoctor.LastEpisodeDate = doctor.LastEpisodeDate;

                _context.Doctors.Update(existingDoctor);

            }

            await _context.SaveChangesAsync();
            return doctor;
        }


    }

}
