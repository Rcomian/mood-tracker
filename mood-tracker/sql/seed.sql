-- Insert a test user
INSERT INTO Users (Username, PasswordHash)
VALUES ('testuser', 'somehashedpassword123');

-- Insert a couple mood entries
INSERT INTO MoodEntries (Mood, Notes, Date, UserId)
VALUES 
    ('Happy', 'Feeling good today', GETUTCDATE(), 1),
    ('Stressed', 'Work is intense', DATEADD(DAY, -1, GETUTCDATE()), 1);

GO
