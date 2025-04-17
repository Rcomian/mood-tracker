-- Get all moods by user
CREATE PROCEDURE GetMoodsByUserId
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, Mood, Notes, Date, UserId
    FROM MoodEntries
    WHERE UserId = @UserId
    ORDER BY Date DESC;
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
