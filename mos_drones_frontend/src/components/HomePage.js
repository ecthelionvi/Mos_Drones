import React, { useState } from 'react';
import drone from '../images/drone.png';
import logo from '../images/logo.png';
import mo from '../images/mo.png';
import '../styles/HomePage.css';

const HomePage = () => {
  const [activeTrackingTab, setActiveTrackingTab] = useState('tracking');
  const [activeHeaderTab, setActiveHeaderTab] = useState('home');

  const handleTrackingTabClick = (tabId) => {
    setActiveTrackingTab(tabId);
  };

  const handleHeaderTabClick = (tabId) => {
    setActiveHeaderTab(tabId);
  };

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
              <div
                className={`header__tab ${activeHeaderTab === 'about' ? 'header__tab--active' : ''}`}
                onClick={() => handleHeaderTabClick('about')}
              >
                <span className="header__tab__span">About</span>
                <div className="header__tab-underline"></div>
              </div>
            </div>
            <button className="header__signin-btn">Sign In &raquo;</button>
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
                    <input type="text" className="tracking-section__tracking-input" placeholder="Enter tracking number" />
                    <button className="tracking-section__tracking-btn">Track &raquo;</button>
                  </div>
                  <div className={`tracking-section__delivery ${activeTrackingTab === 'request-delivery' ? '' : 'hidden'}`}>
                    <input type="text" className="tracking-section__delivery-from" placeholder="From" />
                    <input type="text" className="tracking-section__delivery-to" placeholder="To" />
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
          </main>
        </div>
      </div>
    </div>
  );
};

export default HomePage;
