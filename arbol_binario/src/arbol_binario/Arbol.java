package arbol_binario;

public class Arbol
{
	public Nodo raiz;
	
	public Arbol() {
		raiz = null;
	}
	
	public boolean Vacio() 
	{ 
		return this.raiz == null; 
	}
	
	/*public Nodo buscar(int i, String d)
	{
		Nodo aux = raiz;
		while(aux != null && aux.Dato != d) 
		{
			if(i < aux.Indice) {
				aux = aux.izq;
				
			}else {
				aux = aux.der;
			}
			if(aux == null) {
				return null;
			}
		}
		return aux;
	}*/
	
	public String Buscar(String d) {
		Nodo aux = raiz;
		 if (aux == null) {
		        return null;
		    }
		    int cmp = d.compareTo(aux.Dato);
		    if (cmp < 0) {
		        return get(aux.izq, d);
		    } else if (cmp > 0) {
		        return get1(aux.der, d);
		    } else {
		        return aux.Dato;
		    }
	}
	
	private String get(Nodo izq, String d) {
		return null;
	}
	private String get1(Nodo der, String d) {
		return null;
	}
	
	public void insertar(int i, String d)
	{
		Nodo N = new Nodo(i);
			N.Dato=d;
		if(raiz == null)
		{
			raiz=N;
		}else {
			Nodo aux = raiz;
			Nodo padre;
			while(aux != null) {
				padre = aux;
				if(N.Indice >= aux.Indice)
				{
					aux = aux.der;
					if(aux == null) 
					{
						padre.der=  N;
						return;
					}
				}else {
					aux = aux.izq;
					if(aux == null) 
					{
						padre.izq = N;
						return;
					}
				}
			}
		}
	}
	
	public void imprimir(Nodo n)
	{
			if(n != null)
			{
				imprimir(n.izq);
				System.out.print(n.Dato+" ");
				imprimir(n.der);
			}
	}
	
}
