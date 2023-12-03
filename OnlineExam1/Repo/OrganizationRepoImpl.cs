using OnlineExam1.DTO;
using OnlineExam1.Entity;
using System.Collections.Generic;
using System.Linq;

namespace OnlineExam1.Repo
{
    public class OrganizationRepoImpl : IRepo<OrganizationDTO>
    {
        MyContext context;

        public OrganizationRepoImpl(MyContext ctx)
        {
            context = ctx;
        }

        public bool Add(OrganizationDTO item)
        {
            Organization organization = new Organization
            {
                OrgName = item.Name
            };

            context.Organizations.Add(organization);
            context.SaveChanges();
            return true;
        }

        public List<OrganizationDTO> GetAll()
        {
            var result = context.Organizations
                .Select(o => new OrganizationDTO
                {
                    Id = o.OrgID,
                    Name = o.OrgName
                })
                .ToList();

            return result;
        }

        public Organization GetById(int orgId)
        {
            return context.Organizations.Find(orgId);
        }
        public Organization GetByName(string name)
        {
            return context.Organizations.FirstOrDefault(o => o.OrgName == name);
        }

        public bool Update(int orgId, OrganizationDTO updatedItem)
        {
            var organization = context.Organizations.Find(orgId);

            if (organization == null)
            {
                return false; // Organization not found
            }

            organization.OrgName = updatedItem.Name;

            // If 'OrgID' is the correct property, use it like this:
            organization.OrgID = updatedItem.Id;

            context.SaveChanges();
            return true;
        }

        public bool Delete(int orgId)
        {
            var organization = context.Organizations.Find(orgId);

            if (organization == null)
            {
                return false; // Organization not found
            }

            context.Organizations.Remove(organization);
            context.SaveChanges();
            return true;
        }
    }
}
