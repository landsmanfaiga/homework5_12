import React from 'react';
import { Link } from 'react-router-dom';
import { useCount } from '../CountContextComponent';

const Layout = (props) => {
    const { pendingCount, refusedCount, confirmedCount } = useCount();
    return (
        <div>
            <header>
                <nav className="navbar navbar-expand-sm navbar-dark fixed-top bg-dark border-bottom box-shadow">
                    <div className="container">
                        <a className="navbar-brand">homework5_11</a>
                        <button className="navbar-toggler" type="button" data-toggle="collapse"
                            data-target=".navbar-collapse" aria-controls="navbarSupportedContent"
                            aria-expanded="false" aria-label="Toggle navigation">
                            <span className="navbar-toggler-icon"></span>
                        </button>
                        <div className="navbar-collapse collapse d-sm-inline-flex justify-content-between">
                            <ul className="navbar-nav flex-grow-1">
                                <li className="nav-item"><Link to="/" className='nav-link text-light'>Home</Link></li>
                            </ul>
                            <ul className="navbar-nav flex-grow-1">
                                <li className="nav-item"><Link to="/addcandidate" className='nav-link text-light'>Add Candidate</Link></li>
                            </ul>
                            <ul className="navbar-nav flex-grow-1">
                                <li className="nav-item"><Link to="/pending" className='nav-link text-light'>Pending({pendingCount})</Link></li>
                            </ul>
                            <ul className="navbar-nav flex-grow-1">
                                <li className="nav-item"><Link to="/confirmed" className='nav-link text-light'>Confirmed({confirmedCount})</Link></li>
                            </ul>
                            <ul className="navbar-nav flex-grow-1">
                                <li className="nav-item"><Link to="/refused" className='nav-link text-light'>Refused({refusedCount})</Link></li>
                            </ul>
                        </div>
                    </div>
                </nav>
            </header>
            <div className="container mt-5">
                {props.children}
            </div>
        </div>
    )
}

export default Layout;