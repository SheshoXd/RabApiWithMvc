SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
create function [dbo].[yaf_forum_save_parentschecker](@ForumID int, @ParentID int) returns int as

begin
-- Checks if the forum is already referenced as a parent 
    declare @dependency int
    declare @haschildren int
    declare @frmtmp int
    declare @prntmp int
    
    set @dependency = 0
    set @haschildren = 0
    
    select @dependency=ForumID from [dbo].[yaf_Forum] where ParentID=@ForumID AND ForumID = @ParentID;
    if @dependency > 0
    begin
    return @ParentID
    end

    if exists(select 1 from [dbo].[yaf_Forum] where ParentID=@ForumID)
        begin        
        declare c cursor for
        select ForumID,ParentID from [dbo].[yaf_Forum]
        where ParentID = @ForumID
        
        open c
        
        fetch next from c into @frmtmp,@prntmp
        while @@FETCH_STATUS = 0
        begin
        if @frmtmp > 0 AND @frmtmp IS NOT NULL
         begin        
            set @haschildren= [dbo].[yaf_forum_save_parentschecker](@frmtmp,@ParentID)            
            if  @prntmp = @ParentID
            begin
            set @dependency= @ParentID
            end    
            else if @haschildren > 0
            begin
            set @dependency= @haschildren
            end        
        end
        fetch next from c into @frmtmp,@prntmp
        end
        close c
        deallocate c    
    end
    return @dependency
end
GO
