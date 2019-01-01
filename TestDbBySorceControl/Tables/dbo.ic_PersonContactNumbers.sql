CREATE TABLE [dbo].[ic_PersonContactNumbers]
(
[Id] [uniqueidentifier] NOT NULL,
[PersonId] [uniqueidentifier] NOT NULL,
[ContactNumberId] [uniqueidentifier] NOT NULL,
[IsDeleted] [bit] NOT NULL,
[IsDefault] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_PersonContactNumbers] ADD CONSTRAINT [PK_ic_PersonContactNumbers] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_PersonContactNumbers] ADD CONSTRAINT [FK_ic_PersonContactNumbers_ic_ContactNumbers] FOREIGN KEY ([ContactNumberId]) REFERENCES [dbo].[ic_ContactNumbers] ([Id])
GO
ALTER TABLE [dbo].[ic_PersonContactNumbers] ADD CONSTRAINT [FK_ic_PersonContactNumbers_ic_Persons] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[ic_Persons] ([Id])
GO
