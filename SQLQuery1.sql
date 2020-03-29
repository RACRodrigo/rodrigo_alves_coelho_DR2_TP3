Create procedure [dbo].[DeletePessoa]  
(  
   @StdId int  
)  
as   
begin  
   Delete from PessoaReg where Id=@StdId  
End