import React, {Component} from 'react';
import logo from './logo.svg';
import './App.css';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { FetchData } from './pages/FetchData';
import { Counter } from './pages/Counter';
import { Home } from './pages/Home';
import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data' component={FetchData} />
      </Layout>
    );
  }
  // render (){
  //   return (
  //     <div className="App">
  //     <header className="App-header">
  //       <img src={logo} className="App-logo" alt="logo" />
  //       <p>
  //         Edit <code>src/App.tsx</code> and save to reload.
  //       </p>
  //       <a
  //         className="App-link"
  //         href="https://reactjs.org"
  //         target="_blank"
  //         rel="noopener noreferrer"
  //       >
  //         Learn React
  //       </a>
  //     </header>
  //   </div>
  //   );
  // }
}
