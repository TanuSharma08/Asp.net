CREATE PROCEDURE Search
(
    @ProductName varchar(50),
    @Size varchar(10),
    @Price varchar(20),
    @MfgDate date,
    @Category varchar(20),
    @Conjunction NVARCHAR(3)
)
AS
BEGIN
    SELECT * 
    FROM Product 
    WHERE 
        ProductName = @ProductName
        AND Size = @Size
        AND Price = @Price
        AND MfgDate = @MfgDate
        AND Category = @Category
        AND (@Conjunction = 'AND' OR @Conjunction = 'OR')
END
RETURN 0;




