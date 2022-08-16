import './App.css';
import { BrowserRouter ,NavLink, Route, Routes } from 'react-router-dom';
import {ScreenPrincipal} from './Screens/ScreenPrincipal'
import {ScreenProductosCRUD} from './Screens/ScreenProductosCRUD'
import {ScreenCategorias} from './Screens/ScreenCategorias'
import './css/navbar.css'

function App() {
  return (
    <BrowserRouter>
            <header>
          <nav id='nav'>
            <ul id='navmenu'>
              <li className='navitem'>
                <NavLink to={'/'}>
                  ProductosCRUD
                </NavLink>
              </li>
              <li className='navitem'>
                <NavLink to={'/categoria'}>
                  Categorias
                </NavLink>
              </li>
            </ul>
          </nav>
        </header>
      <div className="App container">
        <h3>FrontEnd</h3>

        <Routes>
          <Route path='/' element={<ScreenProductosCRUD/>}></Route>
          <Route path='/categoria' element={<ScreenCategorias/>}></Route>
        </Routes>

      </div>
    </BrowserRouter>
  );
}

export default App;
