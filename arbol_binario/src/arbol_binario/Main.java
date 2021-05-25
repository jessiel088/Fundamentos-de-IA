package arbol_binario;

public class Main {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Arbol A = new Arbol();
		System.out.println("¿Está vacio?");
		if(A.Vacio()) {
			System.out.println("Vacio");
		}else {
			System.out.println("No está vacio");
		}
		A.insertar(1,"A");
		A.insertar(2,"B");
		A.insertar(1,"C");
		A.insertar(4,"D");
		A.insertar(1,"E");
		A.imprimir(A.raiz);
		System.out.println("¿Está vacio?");
		if(!A.Vacio()) {
			System.out.println("No está vacio");
		}else {
			System.out.println("Vacio");
		}
		if(!A.Vacio()) {
			System.out.println(A.Buscar("a"));
		}else {
			System.out.println("El arbol esta vacio");
		}
		if(!A.Vacio()) {
			System.out.println(A.Buscar("A"));
		}else {
			System.out.println("El arbol esta vacio");
		}
		/*no pude terminar el Buscar falla con cualquier 
		otra letra que no sea la primera que inserté*/
		
	}

}
