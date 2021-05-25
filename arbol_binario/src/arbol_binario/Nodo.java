package arbol_binario;

public class Nodo
{
	String Dato;
	int Indice;
	Nodo izq = null;
	Nodo der = null;

	public Nodo(int indice) 
	{
		this.Indice=indice;
		this.Dato=null;
		this.izq=null;
		this.der=null;
	}
		
	
}
