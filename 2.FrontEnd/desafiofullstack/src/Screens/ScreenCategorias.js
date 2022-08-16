import React, {Component} from "react";
import {variables} from '../API Endpoint/variables'
import './styles.css'

export class ScreenCategorias extends Component{

    constructor(props){
        super(props);

        this.state={
            productos:[]
        }
    }

    refreshData(){
        fetch(variables.API_URL+'categorias')
        .then(response => response.json())
        .then(data =>{
            console.log(data);
            this.setState({
                productos: data
            })
        })
    }

    componentDidMount(){
        this.refreshData();
    }

    abrirModal(){

    }

    render(){
        const {
            productos
        } = this.state;

        return(
            <div>
                <div id="containerTitulo">
                    <h2>Categorias</h2>
                </div>
                <div id="containerProductosTabla">
                    <table id="productosTabla">
                        <thead>
                            <tr>
                                <th>Id Categoria</th>
                                <th>Nombre Producto</th>
                                <th>Descripcion</th>
                            </tr>
                        </thead>
                        <tbody>
                            {productos.map(cat =>{
                                return (<tr key={cat.IdCategoria}>
                                    <td>{cat.IdCategoria}</td>
                                    <td>{cat.NombreCategoria}</td>
                                    <td>{cat.Descripcion}</td>
                                </tr>)
                            })}
                        </tbody>
                    </table>
                </div>
            </div>
        )
    }
}