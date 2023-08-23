import React from "react";
import SideBar from "../components/SideBar";
const AdminLayout = (WrappedComponent) => {
  return class extends React.Component {
    render() {
      return (
        <div className="admin-layout">
          <SideBar/>
          <div className="content">
            <WrappedComponent {...this.props} /> {/* Inject the content component */}
          </div>
        </div>
      );
    }
  };
};

export default AdminLayout;
