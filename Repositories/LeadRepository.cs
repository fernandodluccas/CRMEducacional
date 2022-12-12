using CRMEducacional.Data;
using CRMEducacional.Models;
using Microsoft.EntityFrameworkCore;

namespace CRMEducacional.Repositories
{


    public class LeadRepository : ILeadRepository
    {
        private readonly DataContext _dataContext;

        public LeadRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Create(Lead lead)
        {
            _dataContext.Leads.Add(lead);
            _dataContext.SaveChanges();
        }

        public async void Delete(int id)
        {
            Lead lead = await _dataContext.Leads.FirstOrDefaultAsync(l => l.Id == id);

            if (lead == null)
                throw new Exception("Lead não encontrado");

            _dataContext.Leads.Remove(lead);
            _dataContext.SaveChanges();
        }

        public async Task<IEnumerable<Lead>> GetAllLeads()
        {
            var leads = await _dataContext.Leads.AsNoTracking().ToListAsync();

            if (leads == null)
                throw new Exception("Nenhum lead encontrado");

            return leads;
        }

        public async Task<Lead> GetLeadById(int id)
        {
            Lead lead = await _dataContext.Leads.FirstOrDefaultAsync(l => l.Id == id);

            if (lead == null)
                throw new Exception("Lead não encontrado");

            return lead;
        }

        public async Task<Lead> Update(Lead lead, int id)
        {
            var leadToUpdate = await _dataContext.Leads.FirstOrDefaultAsync(l => l.Id == id);

            if (leadToUpdate == null)
                throw new Exception("Lead não encontrado");

            leadToUpdate.Name = lead.Name;
            leadToUpdate.Email = lead.Email;
            leadToUpdate.CPF = lead.CPF;
            leadToUpdate.Phone = lead.Phone;
            leadToUpdate.Address = lead.Address;
            leadToUpdate.City = lead.City;
            leadToUpdate.State = lead.State;
            leadToUpdate.ZipCode = lead.ZipCode;
            leadToUpdate.Country = lead.Country;
            leadToUpdate.CreatedAt = leadToUpdate.CreatedAt;
            leadToUpdate.UpdatedAt = DateTime.Now;

            _dataContext.Leads.Update(leadToUpdate);
            _dataContext.SaveChanges();

            return leadToUpdate;
        }
    }
}