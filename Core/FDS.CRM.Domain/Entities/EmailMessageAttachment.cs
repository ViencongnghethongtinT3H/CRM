﻿using System;

namespace FDS.CRM.Domain.Entities;

public class EmailMessageAttachment : Entity<Guid>
{
    public Guid EmailMessageId { get; set; }

    public Guid FileEntryId { get; set; }

    public string Name { get; set; }

    public EmailMessage EmailMessage { get; set; }

   // public FileEntry FileEntry { get; set; }
}
