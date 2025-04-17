-- Insert a test user
INSERT INTO Users (Username, PasswordHash)
VALUES ('testuser', '$2a$11$5Srs0.sWQuLrJuRC.3BcWedepfEQI6SX3xBMvqVzB9PaVih8.BgDm'); -- secret123

-- Insert a couple mood entries
INSERT INTO MoodEntries (Mood, Notes, Date, UserId)
VALUES 
    ('Happy', 'Feeling good today', GETUTCDATE(), 1),
    ('Stressed', 'Work is intense', DATEADD(DAY, -1, GETUTCDATE()), 1);

GO
