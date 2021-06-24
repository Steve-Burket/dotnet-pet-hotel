import React, { Component } from 'react';
import PetsTable from './PetsTable';
import PetOwnersTable from './PetOwnersTable';
import axios from 'axios';
import { connect } from 'react-redux';
import { Jumbotron, Container} from 'reactstrap';
import './Home.css';


class Home extends Component {
  static displayName = Home.name;

  fetchPetOwners = async () => {
    const response = await axios.get('api/petOwners');
    this.props.dispatch({ type: 'SET_PETOWNERS', payload: response.data });
  };

  render() {
    return (
      <>
        <Jumbotron fluid className='home-greeting'>
          <Container fluid>
            <h1>Welcome To The Pet Hotel!</h1>
            <p>
              At our Pet Hotel, we take care of your pet while you are away.{' '}
            </p>
            <p>
              <span role='img' aria-label='paw prints'>
                🐾🐾🐾🐾🐾🐾🐾🐾🐾🐾🐾🐾🐾🐾🐾🐾🐾🐾
              </span>
            </p>
          </Container>
        </Jumbotron>
        <PetsTable fetchPetOwners={this.fetchPetOwners} />
        <br />
        <PetOwnersTable fetchPetOwners={this.fetchPetOwners} />
      </>
    );
  }
}

export default connect()(Home);
