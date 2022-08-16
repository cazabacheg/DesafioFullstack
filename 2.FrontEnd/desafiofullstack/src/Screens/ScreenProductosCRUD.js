import React,{Component} from 'react';
import {variables} from '../API Endpoint/variables';
import '../Screens/styles.css'

export class ScreenProductosCRUD extends Component{

    constructor(props){
        super(props);

        this.state={
            categorias:[],
            productos:[],
            modalTitle:"",
            IdProducto:0,
            NombreProducto:"",
            IdCategoria:0,
            PrecioUnidad:"",
        }
    }

    refreshList(){

        fetch(variables.API_URL+'productos')
        .then(response=>response.json())
        .then(data=>{
            this.setState({productos:data});
        });

        fetch(variables.API_URL+'categorias')
        .then(response=>response.json())
        .then(data=>{
            this.setState({categorias:data});
        });
    }

    componentDidMount(){
        this.refreshList();
    }

    cambiarIdProducto =(e)=>{
        this.setState({IdProducto:e.target.value});
    }
    cambiarNombreProducto =(e)=>{
        this.setState({NombreProducto:e.target.value});
    }
    cambiarIdCategoria =(e)=>{
        this.setState({IdCategoria:e.target.value});
    }
    cambiarPrecioUnidad =(e)=>{
        this.setState({PrecioUnidad:e.target.value});
    }

    añadir(){
        this.setState({
            modalTitle:"Nuevo Producto",
            IdProducto:0,
            NombreProducto:"",
            IdCategoria:0,
            PrecioUnidad:0,
        });
    }
    editar(pro){
        this.setState({
            modalTitle:"Editar Producto",
            IdProducto:pro.IdProducto,
            NombreProducto:pro.NombreProducto,
            IdCategoria:pro.IdCategoria,
            PrecioUnidad:pro.PrecioUnidad
        });
    }

    nuevo(){
        fetch(variables.API_URL+'productos',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                IdProducto:this.state.IdProducto,
                NombreProducto:this.state.NombreProducto,
                IdCategoria:this.state.IdCategoria,
                PrecioUnidad:this.state.PrecioUnidad,
                IdCategoriaNavigation: null
            })
        })
        .then(res=>res.json())
        .then((result)=>{
            alert(result);
            this.refreshList();
        },(error)=>{
            alert('Error');
        })
    }


    actualizar(){
        fetch(variables.API_URL+'productos',{
            method:'PUT',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                IdProducto:this.state.IdProducto,
                NombreProducto:this.state.NombreProducto,
                IdCategoria:this.state.IdCategoria,
                PrecioUnidad:this.state.PrecioUnidad,
            })
        })
        .then(res=>res.json())
        .then((result)=>{
            alert(result);
            this.refreshList();
        },(error)=>{
            alert('Error');
        })
    }

    eliminar(id){
        if(window.confirm('¿Esta seguro de eliminar?')){
        fetch(variables.API_URL+'productos/'+id,{
            method:'DELETE',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            }
        })
        .then(res=>res.json())
        .then((result)=>{
            alert(result);
            this.refreshList();
        },(error)=>{
            alert('Error');
        })
        }
    }

    render(){
        const {
            categorias,
            productos,
            modalTitle,
            IdProducto,
            NombreProducto,
            IdCategoria,
            PrecioUnidad
        }=this.state;

        return(
<div id='containerProductosTabla'>

    <h2>Productos CRUD</h2>

    <table id="productosTabla">
    <thead>
    <tr>
        <th>
            Id Producto
        </th>
        <th>
            Nombre Producto
        </th>
        <th>
            Id Categoria
        </th>
        <th>
            Precio Unidad
        </th>
        <th>
            Opciones
        </th>
    </tr>
    </thead>
    <tbody>
        {productos.map(pro=>
            <tr key={pro.IdProducto}>
                <td>{pro.IdProducto}</td>
                <td>{pro.NombreProducto}</td>
                <td>{pro.IdCategoria}</td>
                <td>{pro.PrecioUnidad}</td>
                <td>
                <button type="button"
                data-bs-toggle="modal"
                data-bs-target="#modalProductos"
                onClick={()=>this.editar(pro)}>
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-pencil-square" viewBox="0 0 16 16">
                    <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
                    <path fillRule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z"/>
                    </svg>
                </button>

                <button type="button"
                onClick={()=>this.eliminar(pro.IdProducto)}>
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-trash-fill" viewBox="0 0 16 16">
                    <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z"/>
                    </svg>
                </button>

                </td>
            </tr>
            )}
    </tbody>
    </table>

    <button type="button"
    data-bs-toggle="modal"
    data-bs-target="#modalProductos"
    onClick={()=>this.añadir()}>
        Nuevo Producto
    </button>

<div className="modal fade" id="modalProductos" tabIndex="-1" aria-hidden="true">
<div className="modal-dialog modal-lg modal-dialog-centered">
<div className="modal-content">
   <div className="modal-header">
       <h5 className="modal-title">{modalTitle}</h5>
       <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"
       ></button>
   </div>

   <div className="modal-body">
    <div className="d-flex flex-row bd-highlight mb-3">
     
     <div className="p-2 w-50 bd-highlight">

        <div className="input-group mb-3">
            <span className="input-group-text">IdProducto</span>
            <input type="text" className="form-control"
            value={IdProducto}
            onChange={this.cambiarIdProducto}/>
        </div>
    
        <div className="input-group mb-3">
            <span className="input-group-text">Nombre Producto</span>
            <input type="text" className="form-control"
            value={NombreProducto}
            onChange={this.cambiarNombreProducto}/>
        </div>

        <div className="input-group mb-3">
            <span className="input-group-text">ID Categoria</span>
            <select className="form-select"
            onChange={this.cambiarIdCategoria}
            value={IdCategoria}>
                {categorias.map(cat=><option value={cat.IdCategoria}>
                    {cat.NombreCategoria}
                </option>)}
            </select>
        </div>

        <div className="input-group mb-3">
            <span className="input-group-text">Precio Unidad</span>
            <input type="number" className="form-control"
            value={PrecioUnidad}
            onChange={this.cambiarPrecioUnidad}/>
        </div>


     </div>
    </div>

    {modalTitle==="Nuevo Producto"?
        <button type="button"
        className="btn btn-primary float-start"
        onClick={()=>this.nuevo()}
        >Añadir</button>
        :null}

        {modalTitle==="Editar Producto"?
        <button type="button"
        className="btn btn-primary float-start"
        onClick={()=>this.actualizar()}
        >Actualizar</button>
        :null}
   </div>

</div>
</div> 
</div>


</div>
        )
    }
}