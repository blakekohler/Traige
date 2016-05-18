using System.Linq;
using Abp.Application.Editions;
using Triage.Editions;
using Triage.EntityFramework;

namespace Triage.Migrations.SeedData
{
    public class DefaultEditionsCreator
    {
        private readonly TriageDbContext _context;

        public DefaultEditionsCreator(TriageDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateEditions();
        }

        private void CreateEditions()
        {
            var defaultEdition = _context.Editions.FirstOrDefault(e => e.Name == EditionManager.DefaultEditionName);
            if (defaultEdition == null)
            {
                defaultEdition = new Edition { Name = EditionManager.DefaultEditionName, DisplayName = EditionManager.DefaultEditionName };
                _context.Editions.Add(defaultEdition);
                _context.SaveChanges();

                //TODO: Add desired features to the standard edition, if wanted!
            }   
        }
    }
}