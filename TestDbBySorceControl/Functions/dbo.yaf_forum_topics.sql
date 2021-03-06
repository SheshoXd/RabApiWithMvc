SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
create function [dbo].[yaf_forum_topics](@ForumID int) returns int as

begin
	declare @NumTopics int
	declare @tmp int

	select @NumTopics=NumTopics from [dbo].[yaf_Forum] where ForumID=@ForumID


	if exists(select 1 from [dbo].[yaf_Forum] where ParentID=@ForumID)

	begin
		declare c cursor for
		select ForumID from [dbo].[yaf_Forum]

		where ParentID = @ForumID
		
		open c
		
		fetch next from c into @tmp
		while @@FETCH_STATUS = 0
		begin
			set @NumTopics=@NumTopics+[dbo].[yaf_forum_topics](@tmp)

			fetch next from c into @tmp
		end
		close c
		deallocate c
	end

	return @NumTopics
end
GO
