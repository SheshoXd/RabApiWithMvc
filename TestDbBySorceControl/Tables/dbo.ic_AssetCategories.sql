CREATE TABLE [dbo].[ic_AssetCategories]
(
[AssetId] [int] NOT NULL,
[CategoryId] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_AssetCategories] ADD CONSTRAINT [PK_ic_AssetCategories] PRIMARY KEY CLUSTERED  ([AssetId], [CategoryId]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_AssetCategories] ADD CONSTRAINT [FK_ic_AssetCategories_ic_Assets] FOREIGN KEY ([AssetId]) REFERENCES [dbo].[ic_Assets] ([Id])
GO
ALTER TABLE [dbo].[ic_AssetCategories] ADD CONSTRAINT [FK_ic_AssetCategories_ic_Categories] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[ic_Categories] ([Id])
GO
