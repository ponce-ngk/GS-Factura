select * from PRODUCTO 

--INSERTAR--
INSERT INTO PRODUCTO(PRODUCTO, PRECIO_UNITARIO, STOTCK, ESTADO)
  VALUES ('ARROZ','51.50','40',1);
  select * from PRODUCTO 

--MODIFICAR--
UPDATE PRODUCTO SET PRODUCTO = 'Arroz', PRECIO_UNITARIO='50', STOTCK='100'
WHERE IDPRODUCTO = '1'
select * from PRODUCTO 

--ACTUALIZAR_ELIMINAR--
UPDATE PRODUCTO SET ESTADO = '1'
WHERE IDPRODUCTO = '3'
select * from PRODUCTO 

--ELIMINAR--
DELETE FROM PRODUCTO WHERE IDPRODUCTO= '1'
select * from PRODUCTO 


CREATE PROCEDURE sp_Insertar_PRODUCTO
(
    @producto nchar(30),
    @precio_unitario decimal(10,2),
	@stock decimal(10,2)
)
AS
BEGIN
    INSERT INTO PRODUCTO(PRODUCTO, PRECIO_UNITARIO, STOTCK, ESTADO)
	VALUES (@producto,@precio_unitario,@stock,1);
END

exec sp_Insertar_PRODUCTO ('Aceite',8,30)

CREATE PROCEDURE sp_actualizar_PRODUCTO
(
    @idproducto bigint,
	@producto nchar(30),
    @precio_unitario decimal(10,2),
	@stock decimal(10,2)
)
AS
BEGIN
	UPDATE PRODUCTO SET PRODUCTO = @producto, PRECIO_UNITARIO=@precio_unitario, STOTCK=@stock
	WHERE IDPRODUCTO = @idproducto
    
END

exec sp_actualizar_PRODUCTO (3,ACIETE,12,50)


CREATE PROCEDURE sp_eliminar_PRODUCTO
(
    @idproducto bigint
)
AS
BEGIN

	UPDATE PRODUCTO SET ESTADO = '0'
	WHERE IDPRODUCTO = @idproducto
    
END

exec sp_eliminar_PRODUCTO (3)

CREATE PROCEDURE sp_Mostrar_PRODUCTOS
AS
BEGIN

	select IDPRODUCTO, PRODUCTO, PRECIO_UNITARIO,STOTCK from PRODUCTO WHERE ESTADO = 1
    
END

exec sp_Mostrar_PRODUCTOS