import React, { Component } from 'react';
//import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'


export class Employee extends Component {
    constructor() {
        super();
        this.state = {
            HourlyAnual: 0,
            MonthlyAnual: 0,
            searchId: '',
            Name : "",
            employees: [],
            loading: true
        };
    }

    componentDidMount() {
        this.getEmployees();
    }

    renderSalaryTabla() {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                        <th>SalaryAnual</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {this.state.employees.map(employee =>
                        <tr key={employee.id}>
                            <td>{employee.id}</td>
                            <td>{employee.name}</td>
                            <td>{employee.salaryAnual}</td>
                            
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }


    render() {
        let contents = this.state.loading ? <p><em>Loading...</em></p> : this.renderSalaryTabla();
        return (
            <div>
                <h1 id="tabelLabel" >Employees</h1>
                <div className="input-group mb-3">
                    <div className="input-group-prepend">
                        <button onClick={(event) => this._handleClick(event)} className="btn btn-outline-secondary" type="button">Get Employees</button>
                    </div>
                    <input type="text" className="form-control" placeholder="" aria-label="" aria-describedby="basic-addon1" value={this.state.searchId} onChange={this.handleChange} />
                </div>
                {contents}
            </div>
        );
    }

    async getEmployees() {
        const response = await fetch('api/Employee');
        console.log("response:" + response.data);
        var data = await response.json();
        console.log(data);
        this.setState({
            employees: data,
            loading: false
        });
    }

    async _handleClick(e) {
        e.preventDefault()
        const requestOptions = {
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }

        };
        var url = 'api/Employee';
        if (this.state.searchId !== '') {
            url = '/api/Employee/' + this.state.searchId;
        }
        fetch(url, requestOptions)
            .then((res) => {
                if (res.ok) {
                    return res.json();
                } else {
                    throw new Error('SetLanguage error');
                }
            })
            .then((results) => {
                const list = [];
                console.log(Array.isArray(results));
                if (Array.isArray(results)) {
                    results.map(x => { list.push(x); });
                } else {
                    list.push(results);
                }
                this.filterEmployeesPage(list);
            })
            .catch((err) => {
                console.log(err)
                this.filterEmployeesPage(null);
            });

    }

    handleChange = (e) => {
        const value = e.target.value;
        if (!/\D/.test(value)) {
            this.setState({ searchId: e.target.value });
        }
        
    }

    filterEmployeesPage = (emp) => {
        let list = []
        if (emp !== null) {
            list = emp;
        }
        this.setState({
            employees: list
        });
    }

}
