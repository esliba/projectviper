USE ProyectoViper;
GO

ALTER TABLE dbo.Board 
ADD CONSTRAINT FK_Board_Theme FOREIGN KEY (ThemeId)     
    REFERENCES dbo.Theme (Id)     
    ON DELETE CASCADE    
    ON UPDATE CASCADE    
;    
GO

ALTER TABLE dbo.QContainer 
ADD CONSTRAINT FK_QContainer_Theme FOREIGN KEY (ThemeId)     
    REFERENCES dbo.Theme (Id)     
    ON DELETE CASCADE    
    ON UPDATE CASCADE    
;    
GO

ALTER TABLE dbo.Question 
ADD CONSTRAINT FK_Question_QContainer FOREIGN KEY (QContainerId)     
    REFERENCES dbo.QContainer (Id)     
    ON DELETE CASCADE    
    ON UPDATE CASCADE    
;    
GO

ALTER TABLE dbo.Question 
ADD CONSTRAINT FK_Question_QOption FOREIGN KEY (QOptionId)     
    REFERENCES dbo.QOption (Id)     
    ON DELETE CASCADE    
    ON UPDATE CASCADE    
;    
GO