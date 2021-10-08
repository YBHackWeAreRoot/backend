SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      Matthias Schneeberger
-- Create Date: 08.10.2021
-- Description: Generates ParkingSlots for a ParkingSpace 
-- =============================================
CREATE PROCEDURE GenerateParkingSlots
(
	@ParkingSpaceId uniqueidentifier,
    @NumberOfSlots int
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

	WITH InfiniteRows (RowNumber) AS (
	   -- Anchor member definition
	   SELECT 1 AS RowNumber
	   UNION ALL
	   -- Recursive member definition
	   SELECT a.RowNumber + 1    AS RowNumber
	   FROM   InfiniteRows a
	   WHERE  a.RowNumber < @NumberOfSlots
	)
	-- Statement that executes the CTE
	INSERT INTO [dbo].ParkingSlot (ParkingSpaceId)
	SELECT @ParkingSpaceId
	FROM   InfiniteRows
	OPTION (MAXRECURSION 0);
END
GO