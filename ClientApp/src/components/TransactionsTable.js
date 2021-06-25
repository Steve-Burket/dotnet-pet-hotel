import React, { Component } from 'react';
import axios from 'axios';
import { connect } from 'react-redux';
import { Table } from 'reactstrap';

class TransactionsTable extends Component {


  componentDidMount = () => {
    this.fetchData();
  };

  fetchData = async () => {
    try {
      const response = await axios.get('/api/transaction/');
      this.props.dispatch({ type: 'SET_TRANSACTION', payload: response.data });

      // stretch goal 1: grab transactions from the backend

    } catch (err) {
      console.log('There was an error...oops!');
    }
  }



  render = () => {

    return (
      <div class='table-responsive'>
        <Table
          dark
          className='table table-striped table-bordered table-hover'
          aria-labelledby='tabelLabel'
        >
          <thead>
            <tr>
              <th>Transaction</th>
              <th>Description</th>
            </tr>
          </thead>
          <tbody>
            {this.props.transactions.map((transaction) => (
              <tr key={transaction.id}>
                <td>{transaction.transaction}</td>
                <td>{transaction.description}</td>
              </tr>
            ))}
          </tbody>
        </Table>
      </div>


    )
  }
};



const mapStateToProps = (store) => ({
  transactions: store.transactions,
});

export default connect(mapStateToProps)(TransactionsTable);
