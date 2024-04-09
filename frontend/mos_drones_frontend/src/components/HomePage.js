import React, { useState, useRef, useEffect } from 'react';
import drone from '../images/drone.png';
import logo from '../images/logo.png';
import mo from '../images/mo.png';
import pkg from '../images/package.png'
import '../styles/HomePage.css';
import PackageGrid from './PackageGrid'
import { useJsApiLoader, Autocomplete } from '@react-google-maps/api';
import { NavLink, useNavigate } from 'react-router-dom';

const HomePage = ({ loggedIn, onLogout, setLoggedIn }) => {
  const [activeTrackingTab, setActiveTrackingTab] = useState('tracking');
  const [activeHeaderTab, setActiveHeaderTab] = useState(loggedIn ? 'dashboard' : 'home');
  const [trackingNumber, setTrackingNumber] = useState('');
  const fromAutocompleteRef = useRef(null);
  const toAutocompleteRef = useRef(null);
  const navigate = useNavigate();

  const { isLoaded } = useJsApiLoader({
    id: 'google-map-script',
    googleMapsApiKey: 'AIzaSyCfTn6UID_1mfAbHLjaFNsgAww13JewQzE',
    libraries: ['places'],
  });

  const handleTrackButtonClick = () => {
    if (trackingNumber) {
      navigate(`/package/${trackingNumber}`);
    }
  };

  const handleEnterKey = (e) => {
    if (e.key === 'Enter') {
      handleTrackButtonClick();
    }
  };

  const handleTrackingTabClick = (tabId) => {
    setActiveTrackingTab(tabId);
  };

  const handleHeaderTabClick = (tabId) => {
    setActiveHeaderTab(tabId);
  };

  const onPlaceChanged = (autocompleteRef) => {
    if (autocompleteRef.current) {
      const place = autocompleteRef.current.getPlace();
      console.log("Selected place:", place);
    }
  };

  useEffect(() => {
    setActiveHeaderTab(loggedIn ? 'dashboard' : 'home');
  }, [loggedIn]);


  return (
    <div className="homepage-body">
      <div className="body-container">
        <div className="page-container">
          <header className="header">
            <img className="header__logo" src={logo} alt="Mo's Drones Logo" />
            <div className="header__tabs">
              <div
                className={`header__tab ${activeHeaderTab === 'home' ? 'header__tab--active' : ''}`}
                onClick={() => handleHeaderTabClick('home')}
              >
                <span className="header__tab__span">Home</span>
                <div className="header__tab-underline"></div>
              </div>
              {loggedIn && (
                <div
                  className={`header__tab ${activeHeaderTab === 'dashboard' ? 'header__tab--active' : ''}`}
                  onClick={() => handleHeaderTabClick('dashboard')}
                >
                  <span className="header__tab__span">Dashboard</span>
                  <div className="header__tab-underline"></div>
                </div>
              )}
              {loggedIn && (
                <div
                  className={`header__tab ${activeHeaderTab === 'account' ? 'header__tab--active' : ''}`}
                  onClick={() => handleHeaderTabClick('account')}
                >
                  <span className="header__tab__span">Account</span>
                  <div className="header__tab-underline"></div>
                </div>
              )}
              <div
                className={`header__tab ${activeHeaderTab === 'about' ? 'header__tab--active' : ''}`}
                onClick={() => handleHeaderTabClick('about')}
              >
                <span className="header__tab__span">About</span>
                <div className="header__tab-underline"></div>
              </div>
            </div>
            {loggedIn ? (
              <button className="header__signout-btn" onClick={onLogout}>
                Sign Out &raquo;
              </button>
            ) : (
              <NavLink to="/login">
                <button className="header__signin-btn">Sign In &raquo;</button>
              </NavLink>
            )}
          </header>
          <main className="main-content">
            <section className={`home-section ${activeHeaderTab === 'home' ? '' : 'hidden'}`}>
              <section className="tracking-section">
                <div className="tracking-section__tabs">
                  <div
                    className={`tracking-section__tab ${activeTrackingTab === 'tracking' ? 'tracking-section__tab--active' : ''}`}
                    onClick={() => handleTrackingTabClick('tracking')}
                  >
                    <span className="tracking-section__tab__span">Tracking</span>
                    <div className="tracking-section__tab-underline"></div>
                  </div>
                  <div
                    className={`tracking-section__tab ${activeTrackingTab === 'request-delivery' ? 'tracking-section__tab--active' : ''}`}
                    onClick={() => handleTrackingTabClick('request-delivery')}
                  >
                    <span className="tracking-section__tab__span">Request Delivery</span>
                    <div className="tracking-section__tab-underline"></div>
                  </div>
                </div>
                <div className="tracking-section__content">
                  <div className={`tracking-section__tracking ${activeTrackingTab === 'tracking' ? '' : 'hidden'}`}>
                    <input
                      type="text"
                      className="tracking-section__tracking-input"
                      placeholder="Enter tracking number"
                      value={trackingNumber}
                      onChange={(e) => setTrackingNumber(e.target.value)}
                      onKeyPress={handleEnterKey}
                    />
                    <button className="tracking-section__tracking-btn" onClick={handleTrackButtonClick}>
                      Track &raquo;
                    </button>
                  </div>
                  <div className={`tracking-section__delivery ${activeTrackingTab === 'request-delivery' ? '' : 'hidden'}`}>
                    {isLoaded && (
                      <>
                        <Autocomplete
                          onLoad={(autocomplete) => { fromAutocompleteRef.current = autocomplete; }}
                          onPlaceChanged={() => onPlaceChanged(fromAutocompleteRef)}
                        >
                          <input type="text" className="tracking-section__delivery-from" placeholder="From" />
                        </Autocomplete>
                        <Autocomplete
                          onLoad={(autocomplete) => { toAutocompleteRef.current = autocomplete; }}
                          onPlaceChanged={() => onPlaceChanged(toAutocompleteRef)}
                        >
                          <input type="text" className="tracking-section__delivery-to" placeholder="To" />
                        </Autocomplete>
                      </>
                    )}
                    <button className="tracking-section__delivery-btn">Request Delivery &raquo;</button>
                  </div>
                </div>
              </section>
              <div className="content-wrapper">
                <img className="main-image-top" src={drone} alt="Drone with Package" />
                <h1 className="main-title">World-Class Services<br />You Can Count On</h1>
                <div className="title-underline"></div>
                <p className="main-slogan">Nebraska Skies, Swift Supplies</p>
              </div>
            </section>
            <section className={`about-section ${activeHeaderTab === 'about' ? '' : 'hidden'}`}>
              <h2>About Us</h2>
              <div className="about-section__underline"></div>
              <p className="about-section-paragraph">
                Welcome to Mo's Drones, where innovation meets convenience in the world of delivery services. At Mo's Drones, we're passionate about revolutionizing the way goods are transported, bringing unparalleled speed, efficiency, and reliability to your doorstep.
              </p>
              <div className="image-container">
                <img className="about-image-top" src={mo} alt="Mr. Mo" />
                <div className="speech-bubble">
                  <p className="speech-bubble-paragraph">Take it from me, Mr. Mo</p>
                </div>
              </div>
            </section>
            <section className={`dashboard-section ${activeHeaderTab === 'dashboard' ? '' : 'hidden'}`}>
              <h2>Packages</h2>
              <div className="dashboard-section__underline"></div>
              <PackageGrid />
              <img className="dashboard-image-bottom" src={pkg} alt="Package" />
            </section>
          </main>
        </div>
      </div>
    </div>
  );
};

export default HomePage;
