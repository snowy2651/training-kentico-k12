﻿using System.Linq;
using CMS.DocumentEngine.Types.Training;
using Kentico.Dto.Contact;
using Kentico.Services.Query;

namespace Kentico.Repository.Contact
{
    public class ContactSectionRepository : BaseRepository, IContactSectionRepository
    {

        public ContactSectionRepository(IDocumentQueryService documentQueryService) : base(documentQueryService)
        {
        }

        public ContactSectionDto GetContactSection()
        {
            return DocumentQueryService.GetDocuments<ContactSection>()
                .TopN(1)
                .AddColumns("Title", "Subtitle", "Text")
                .ToList()
                .Select(m => new ContactSectionDto()
                {
                    Header = m.Title,
                    Subheader = m.Subtitle,
                    Text = m.Text,

                })
                .FirstOrDefault();
        }
    }
}
