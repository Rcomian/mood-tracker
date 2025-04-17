-- Get all moods by user
CREATE PROCEDURE GetMoodsByUserId
    @UserId INT,
    @Page INT = 1,
    @PageSize INT = 20
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Offset INT = (@Page - 1) * @PageSize;

    -- Return total count
    SELECT COUNT(*) AS TotalCount
    FROM MoodEntries
    WHERE UserId = @UserId;
    
    -- Return paged data
    SELECT Id, Mood, Notes, Date, UserId
    FROM MoodEntries
    WHERE UserId = @UserId
    ORDER BY Date DESC
    OFFSET @Offset ROWS
    FETCH NEXT @PageSize ROWS ONLY;
END
GO

-- Insert a new mood entry
CREATE PROCEDURE InsertMoodEntry
    @UserId INT,
    @Mood NVARCHAR(50),
    @Notes NVARCHAR(MAX),
    @Date DATETIME
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO MoodEntries (Mood, Notes, Date, UserId)
    VALUES (@Mood, @Notes, @Date, @UserId);
END
GO
