namespace DoctorWho.Db.Repository
{
    public interface IDoctorRepository
    {
        Task<List<Doctor>> GetAllDoctorsAsync();
        Task AddDoctorAsync(Doctor doctor);
        Task UpdateDoctorAsync(Doctor doctor);
        Task<bool> DeleteDoctorAsync(int doctorId);
        Task<Doctor> UpsertDoctorAsync(int DoctorId, Doctor doctor);
    }
}