-- Insert rows into table 'AirworthinessType'
INSERT INTO AirworthinessType
( -- columns to insert data into
 [Abbreviation], [LongName]
)
VALUES
( -- first row: values for the columns in the list above
 'STD', 'Standard'
),
( -- second row: values for the columns in the list above
 'EXP', 'Expiramental'
),
(
    'MSX', 'Military Surplus'
),
(
    'RST', 'Restricted'
)
GO