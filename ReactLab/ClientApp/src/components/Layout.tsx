import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';

export interface LayoutState{
  }
  
  export interface LayoutOption{
    children:any
  }

export class Layout extends Component<LayoutOption,LayoutState> {
  static displayName = Layout.name;

  render () {
    return (
      <div>
        <NavMenu />
        <Container>
          {this.props.children}
        </Container>
      </div>
    );
  }
}
